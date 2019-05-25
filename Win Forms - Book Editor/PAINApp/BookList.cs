using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAINApp
{   
    public partial class BookList : Form
    {
        private static readonly string FilterAll = "All";
        private static readonly string FilterAfter2000 = "After year 2000";
        private static readonly string FilterBefore2000 = "Before year 2000";
        
        private BooksDocument booksDocument { get; set; }

        public event Action<int> NumberOfElementsUpdate;

        public BookList(BooksDocument document)
        {
            InitializeComponent();
            booksDocument = document;
            
        }

        private void BookList_Load(object sender, EventArgs e)
        {
            FilterComboBox.SelectedIndex = 0;
            if(Form.ActiveForm == this)
                NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
            booksDocument.AddBookEvent += Document_AddBookEvent;      
            booksDocument.UpdateBookEvent += Document_UpdateBookEvent;
            booksDocument.DeleteBookEvent += Document_DeleteBookEvent;
        }

        private void Document_AddBookEvent(Book book)
        {
            if (isFiltered(book))
                return;
            ListViewItem item = new ListViewItem();
            item.Tag = book;
            UpdateItem(item);
            booksListView.Items.Add(item);
            if (Form.ActiveForm == this)
                NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
        }

        private void Document_UpdateBookEvent(Book book)
        {
            foreach (ListViewItem item in booksListView.Items)
            {
                if (ReferenceEquals(item.Tag, book))
                {
                    if (isFiltered(book))
                    {
                        booksListView.Items.Remove(item);
                        if (Form.ActiveForm == this)
                            NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
                        return;
                    }
                    else
                    {
                        UpdateItem(item);
                        return;
                    }
                }
            }
            Document_AddBookEvent(book);
            if (Form.ActiveForm == this)
                NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
        }

        private void Document_DeleteBookEvent(Book book)
        {
            foreach(ListViewItem item in booksListView.Items)
            {
                if(ReferenceEquals(item.Tag, book))
                {
                    booksListView.Items.Remove(item);
                    if (Form.ActiveForm == this)
                        NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
                    break;
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(null, booksDocument.books);
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                Book newBook = new Book(bookForm.Title, bookForm.Author, bookForm.RecordingDate, bookForm.Genre);

                booksDocument.AddBook(newBook);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (booksListView.SelectedItems.Count == 1)
            {
                Book book = (Book)booksListView.SelectedItems[0].Tag;
                BookForm bookForm = new BookForm(book, booksDocument.books);
                if (bookForm.ShowDialog() == DialogResult.OK)
                {
                    book.Title = bookForm.Title;
                    book.Author = bookForm.Author;
                    book.RecordingDate = bookForm.RecordingDate;
                    book.Genre = bookForm.Genre;

                    booksDocument.UpdateBook(book);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (booksListView.SelectedItems.Count == 1)
            {
                Book book = (Book)booksListView.SelectedItems[0].Tag;
                booksDocument.DeleteBook(book);             
            }
        }

        private void UpdateItem(ListViewItem item)
        {
            Book book = (Book)item.Tag;
            while (item.SubItems.Count < 4)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = book.Title;
            item.SubItems[1].Text = book.Author;
            item.SubItems[2].Text = book.RecordingDate.ToShortDateString();
            item.SubItems[3].Text = book.Genre;
           
        }

        private void UpdateItems()
        {
            booksListView.Items.Clear();
            foreach (Book book in booksDocument.books)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = book;
                UpdateItem(item);
                booksListView.Items.Add(item);
            }
            if (Form.ActiveForm == this)
                NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
        }

        private void UpdateAndFilterItems()
        {
            string selectedFilter = (string)FilterComboBox.SelectedItem;
            if (selectedFilter.Equals(FilterAll))
            {
                UpdateItems();
                return;
            }               

            booksListView.Items.Clear();
            DateTime year2000 = new DateTime(2000, 1, 1);

            if (selectedFilter.Equals(FilterAfter2000))
            {
                booksDocument.books.ForEach(book =>
                {
                    if (DateTime.Compare(book.RecordingDate, year2000) > 0)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = book;
                        UpdateItem(item);
                        booksListView.Items.Add(item);
                    }                  
                });              
            }
            else
            {
                booksDocument.books.ForEach(book =>
                {
                    if (DateTime.Compare(book.RecordingDate, year2000) < 0)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = book;
                        UpdateItem(item);
                        booksListView.Items.Add(item);
                    }
                });
            }
            NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            UpdateAndFilterItems();
        }

        private bool isFiltered(Book book)
        {

            string selectedFilter = (string)FilterComboBox.SelectedItem;
            DateTime year2000 = new DateTime(2000, 1, 1);
            
            return selectedFilter.Equals(FilterAfter2000) && DateTime.Compare(book.RecordingDate, year2000) < 0
                || selectedFilter.Equals(FilterBefore2000) && DateTime.Compare(book.RecordingDate, year2000) > 0;
        }

        private void BookList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MdiParent.MdiChildren.Length == 1;
        }

        private void FocusActivated(object sender, EventArgs e)
        {
            NumberOfElementsUpdate?.Invoke(booksListView.Items.Count);
        }

        private void BooksListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
