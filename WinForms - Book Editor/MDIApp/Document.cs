using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIApp
{
    public class Document
    {
        public List<Book> books = new List<Book>();

        public event Action<Book> AddBookEvent;
        public event Action<Book> UpdateBookEvent;
        public event Action<Book> DeleteBookEvent;

        public void AddBook( Book book )
        {
            books.Add(book);

            AddBookEvent?.Invoke(book);
        }

        public void UpdateBook(Book book)
        {
            UpdateBookEvent?.Invoke(book);
        }

        public void DeleteBook(Book deletedBook)
        {
            books.Remove(deletedBook);
            DeleteBookEvent?.Invoke(deletedBook);
        }
    }
}
