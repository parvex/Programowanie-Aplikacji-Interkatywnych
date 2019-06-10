using System;
using Books.Model;

namespace Books.Viewmodel.AddBook
{
    class AddBookViewModel
    {
        private Book book;

        public Book Book
        {
            get
            {
                return book;
            }
        }

        public String Title{ get; set; }

        public String Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public String Genre { get; set; }

        private CancelAddBookCommand cancelAddBookCommand = new CancelAddBookCommand();

        private AddAddBookCommand addAddBookCommand;

        public CancelAddBookCommand CancelAddBookCommand
        {
            get
            {
                return cancelAddBookCommand;
            }
        }

        public AddAddBookCommand AddAddBookCommand
        {
            get
            {
                return addAddBookCommand;
            }
        }

        public AddBookViewModel(Book book, bool isEditMode)
        {
            this.book = book;

            ReleaseDate = DateTime.Now;

            if (isEditMode)
            {
                Title = book.Title;
                Author = book.Author;
                ReleaseDate = book.ReleaseDate;
                Genre = book.Genre;
            }

            addAddBookCommand = new AddAddBookCommand()
            {
                CanExecuteAction = p => !IsAnyFieldNotFilled(),
                ExecuteAction = a => UpdateBook()
            };
        }

        private bool IsAnyFieldNotFilled()
        {
            return (String.IsNullOrEmpty(Author) || String.IsNullOrEmpty(Title)
                || String.IsNullOrEmpty(Genre) || DateTime.MinValue.Equals(ReleaseDate));
        }

        private void UpdateBook()
        {
            book.Title = Title;
            book.Author = Author;
            book.ReleaseDate = ReleaseDate;
            book.Genre = Genre;
        }
    }
}
