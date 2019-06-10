using System.Collections.Generic;
using System.Windows;
using Books.View;
using Books.Viewmodel.BookList;

namespace Books_WPF_App
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<MainWindow> mainWindows;

        protected override void OnStartup(StartupEventArgs e)
        {
            mainWindows = new List<MainWindow>();

            InitializeComponent();

            CreateNewView();
        }

        private void CreateNewView()
        {
            BookListViewModel viewModel = new BookListViewModel
            {
                ClosingAction = ev => HandleClosingApplication(ev),
                CreatingViewAction = ev => CreateNewView()
            };

            MainWindow bookFirstWindow = new MainWindow
            {
                DataContext = viewModel,
                Visibility = Visibility.Visible,
            };
            bookFirstWindow.Closing += (s, ev) => viewModel.HandleClosingWindow(s);
            mainWindows.Add(bookFirstWindow);
            bookFirstWindow.Show();
        }

        private void HandleClosingApplication(object ev)
        {
            mainWindows.Remove(ev as MainWindow);
            if (mainWindows.Count.Equals(0))
            {
                Application.Current.Shutdown();
            }
        }
    }
}
