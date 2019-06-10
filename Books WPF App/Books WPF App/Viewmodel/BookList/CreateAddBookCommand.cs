using System;
using System.Windows.Input;

namespace Books.Viewmodel.BookList
{
    class CreateAddBookCommand : ICommand
    {
        public Action<object> ExecuteAction;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (ExecuteAction != null)
            {
                ExecuteAction(parameter);
            }
        }
    }
}
