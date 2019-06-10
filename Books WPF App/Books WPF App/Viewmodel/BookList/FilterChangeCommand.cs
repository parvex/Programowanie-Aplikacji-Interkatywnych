using System;
using System.Windows.Input;

namespace Books.Viewmodel.BookList
{
    class FilterChangeCommand : ICommand
    {
        private static readonly int MORE_EQUAL_FILTER_VALUE = 1;
        private static readonly int LESS_FILTER_VALUE = -1;
        private static readonly int CLEAR_FILTER_VALUE = 0; 

        public Action<object> ExecuteLessFilterAction;

        public Action<object> ExecuteMoreEqualFilterAction;

        public Action<object> ExecuteClearFilterAction;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int filterValue = (int)parameter;
            if (filterValue == LESS_FILTER_VALUE)
            {
                ExecuteLessFilterAction(parameter);
            }
            else if (filterValue == MORE_EQUAL_FILTER_VALUE)
            {
                ExecuteMoreEqualFilterAction(parameter);
            }
            else
            {
                ExecuteClearFilterAction(parameter);
            }
        }
    }
}
