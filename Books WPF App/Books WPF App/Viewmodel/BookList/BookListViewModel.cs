using System;
using System.Windows.Data;
using Books.Model;
using Books.Viewmodel.AddBook;

namespace Books.Viewmodel.BookList
{
    class BookListViewModel
    {
        public Action<object> ClosingAction;

        public Action<object> CreatingViewAction;

        public Book SelectedBook { get; set; }

        public CollectionViewSource CollectionViewSource { get; set; }

        private CreateAddBookCommand createAddBookCommand;

        public CreateAddBookCommand CreateAddBookCommand
        {
            get
            {
                return createAddBookCommand;
            }
        }

        private FilterChangeCommand filterChangeCommand;

        public FilterChangeCommand FilterChangeCommand
        {
            get
            {
                return filterChangeCommand;
            }
        }

        private DeleteBookCommand deleteBookCommand;

        public DeleteBookCommand DeleteBookCommand
        {
            get
            {
                return deleteBookCommand;
            }
        }

        private CreateViewCommand createViewCommand;

        public CreateViewCommand CreateViewCommand
        {
            get
            {
                return createViewCommand;
            }
        }

        public BookListViewModel()
        {
            CollectionViewSource = new CollectionViewSource();
            CollectionViewSource.Source = MainModel.Books;

            filterChangeCommand = new FilterChangeCommand()
            {
                ExecuteLessFilterAction = f => SetFilterLessThan(),
                ExecuteMoreEqualFilterAction = f => SetFilterMoreEqual(),
                ExecuteClearFilterAction = f => ClearFilter()
            };

            createAddBookCommand = new CreateAddBookCommand()
            {
                ExecuteAction = a => addNewBook(a)
            };

            deleteBookCommand = new DeleteBookCommand()
            {
                ExecuteAction = d => deleteBook(d)
            };

            createViewCommand = new CreateViewCommand()
            {
                ExecuteAction = c => HandleCreatingNewView()
            };
        }

        private void deleteBook(object moveToDelete)
        {
            Book book = moveToDelete as Book;
            if (book != null)
            {
                MainModel.Books.Remove(book);
            }
        }

        public void HandleClosingWindow(object mainWindow)
        {
            ClosingAction(mainWindow);
        }

        public void HandleCreatingNewView()
        {
            CreatingViewAction(this);
        }

        private void addNewBook(object a)
        {
            View.AddBook addBook = null;
            AddBookViewModel viewModel = null;
            if (a != null)
            {
                addBook = new View.AddBook();
                viewModel = new AddBookViewModel(a as Book, true);
                addBook.DataContext = viewModel;
                addBook.ShowDialog();
                return;
            }
            Book book = new Book();
            addBook = new View.AddBook();
            viewModel = new AddBookViewModel(book, false);
            addBook.DataContext = viewModel;
            addBook.ShowDialog();

            if(book.IsValid())
            {
                MainModel.Books.Add(book);
            }

        }

        private bool FilterMoreEquals(object o)
        {
            Book book = o as Book;
            if (book == null)
                return false;
            return book.ReleaseDate.Year >= 1997;
        }

        private bool FilterLess(object o)
        {
            Book book = o as Book;
            if (book == null)
                return false;
            return book.ReleaseDate.Year < 1997;
        }

        public void SetFilterLessThan()
        {
            CollectionViewSource.View.Filter = FilterLess;
        }

        public void SetFilterMoreEqual()
        {
            CollectionViewSource.View.Filter = FilterMoreEquals;
        }

        public void ClearFilter()
        {
            CollectionViewSource.View.Filter = null;
        }
    }
}
