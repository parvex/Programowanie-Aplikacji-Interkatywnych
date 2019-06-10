using System;
using System.Windows.Input;

namespace Books.Viewmodel.AddBook
{
    class AddAddBookCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<object> ExecuteAction { get; set; }

        public Predicate<object> CanExecuteAction { get; set; }

        public bool CanExecute(object parameter)
        {
            View.AddBook addBook = parameter as View.AddBook;
            if (CanExecuteAction != null && addBook != null)
            {
                AddBookViewModel viewModel = addBook.DataContext as AddBookViewModel;
                return CanExecuteAction(viewModel);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            View.AddBook addBook = parameter as View.AddBook;
            AddBookViewModel viewModel = addBook.DataContext as AddBookViewModel;
            if (ExecuteAction != null)
            {
                ExecuteAction(addBook.DataContext);
            }
            viewModel = null;
            addBook.Close();
        }
    }
}
