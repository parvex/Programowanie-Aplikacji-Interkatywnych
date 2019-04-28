using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIApp
{
    public partial class BooksList : Form
    {
        private Document Document { get; set; }

        public BooksList( Document document )
        {
            InitializeComponent();
            Document = document;
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddBookEvent += Document_AddBookEvent;
            Document.UpdateBookEvent += Document_UpdateBookEvent;
            Document.DeleteBookEvent += Document_DeleteBookEvent;
        }

        private void Document_AddBookEvent(Book book)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = book;
            UpdateItem(item);
            booksListView.Items.Add(item);
        }

        private void Document_UpdateBookEvent(Book Book)
        {
            foreach (ListViewItem item in booksListView.Items)
            {
                if (!ReferenceEquals(item.Tag, Book)) continue;
                UpdateItem(item);
                break;
            }
        }

        private void Document_DeleteBookEvent(Book Book)
        {
            foreach (ListViewItem item in booksListView.Items)
            {
                if (!ReferenceEquals(item.Tag, Book)) continue;
                booksListView.Items.Remove(item);
                break;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(null, Document.books);
            if( bookForm.ShowDialog() == DialogResult.OK)
            {
                Book newBook = new Book(bookForm.BookId, bookForm.BookTitle, bookForm.BookAuthor, bookForm.BookReleaseDate, bookForm.BookGenre);

                Document.AddBook(newBook);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( booksListView.SelectedItems.Count == 1)
            {
                Book book = (Book)booksListView.SelectedItems[0].Tag;
                BookForm bookForm = new BookForm(book, Document.books);
                if (bookForm.ShowDialog() == DialogResult.OK)
                {
                    book.Title = bookForm.BookTitle;
                    book.Id = bookForm.BookId;
                    book.ReleaseDate = bookForm.BookReleaseDate;
                    book.Author = bookForm.BookAuthor;
                    book.Genre = bookForm.BookGenre;

                    Document.UpdateBook(book);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (booksListView.SelectedItems.Count == 1)
            {
                Book book = (Book)booksListView.SelectedItems[0].Tag;
                Document.DeleteBook(book);
            }
        }

        private void UpdateItem( ListViewItem item)
        {
            Book book = (Book)item.Tag;
            while (item.SubItems.Count < 5)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = book.Id.ToString();
            item.SubItems[1].Text = book.Title;
            item.SubItems[2].Text = book.ReleaseDate.ToShortDateString();
            item.SubItems[3].Text = book.Author;
            item.SubItems[4].Text = book.Genre.ToString();
        }

        private void UpdateItems()
        {
            booksListView.Items.Clear();
            foreach( Book student in Document.books)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = student;
                UpdateItem(item);
                booksListView.Items.Add(item);
            }
        }
    }
}
