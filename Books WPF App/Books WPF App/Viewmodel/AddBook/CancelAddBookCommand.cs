using System;
using System.Windows.Input;

namespace Books.Viewmodel.AddBook
{
    class CancelAddBookCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            View.AddBook addBook = parameter as View.AddBook;
            AddBookViewModel viewModel = addBook.DataContext as AddBookViewModel;
            viewModel.Book.ResetValues();
            viewModel = null;
            addBook.Close();
        }
    }
}
