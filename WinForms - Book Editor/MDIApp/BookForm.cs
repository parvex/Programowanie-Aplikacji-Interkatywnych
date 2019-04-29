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
    public partial class BookForm : Form
    {
        private Book _book;
        private List<Book> students;

        public string BookTitle
        {
            get { return nameTextBox.Text; }
        }

        public long BookId
        {
            get { return long.Parse( indexTextBox.Text ); }
        }

        public DateTime BookReleaseDate
        {
            get { return releaseDateTimePicker.Value; }
        }

        public string BookAuthor
        {
            get { return authorTextBox.Text; }
        }

        public string BookGenre
        {
            get
            {
                return genreComboBox.SelectedItem.ToString();
            }
        }

        public BookForm(Book book, List<Book> students)
        {
            InitializeComponent();
            this._book = book;
            this.students = students;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (_book != null)
            {
                nameTextBox.Text = _book.Title;
                indexTextBox.Text = _book.Id.ToString();
                releaseDateTimePicker.Value = _book.ReleaseDate;
                genreComboBox.SelectedItem = _book.Genre;
                authorTextBox.Text = _book.Author;
            }
            else
            {
                releaseDateTimePicker.Value = new DateTime(2005, 1, 1);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void IndexTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                long index = long.Parse(indexTextBox.Text);
                foreach (Book s in students)
                    if (s.Id == index && !ReferenceEquals(s, _book))
                        throw new Exception( "Book already exists." );
            }
            catch( Exception exception )
            {
                e.Cancel = true;
                errorProvider.SetError(indexTextBox, exception.Message);
            }
        }

        private void IndexTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(indexTextBox, "");
        }

        private void authorTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string author = authorTextBox.Text;
                if (String.IsNullOrEmpty(author))
                    throw new Exception("Author cannot be empty.");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider.SetError(authorTextBox, exception.Message);
            }
        }

        private void authorTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(authorTextBox, "");
        }

        private void releaseDateTimePicker_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(authorTextBox, "");
        }

        private void releaseDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime recordingDate = releaseDateTimePicker.Value;
                if (recordingDate == null)
                    throw new Exception("You have to choose date.");
                if (DateTime.Compare(recordingDate, DateTime.Today) > 0)
                    throw new Exception("You cannot choose date from the future.");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider.SetError(releaseDateTimePicker, exception.Message);
            }
        }

        private void nameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(authorTextBox, "");
        }

        private void IndexTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
