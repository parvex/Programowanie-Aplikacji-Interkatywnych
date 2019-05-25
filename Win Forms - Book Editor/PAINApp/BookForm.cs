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
    public partial class BookForm : Form
    {
        private Book book; 
        private List<Book> books;

        public string Title
        {
            get { return TitleTextBox.Text; }
        }

        public string Author
        {
            get { return AuthorTextBox.Text; }
        }

        public DateTime RecordingDate
        {
            get { return RecordingDatePicker.Value; }
        }

        public string Genre
        {
            get { return genreLabel.Text; }
        }

        public BookForm()
        {
            InitializeComponent();
            genreControl.genreChangeEvent += genreControlChanged;
        }

        public BookForm(Book book, List<Book> books)
        {
            InitializeComponent();
            this.book = book;
            this.books = books;
            genreControl.genreChangeEvent += genreControlChanged;
        }


        private void BookForm_Load(object sender, EventArgs e)
        {
            if (book != null)
            {
                TitleTextBox.Text = book.Title;
                AuthorTextBox.Text = book.Author;
                RecordingDatePicker.Value = book.RecordingDate;
                Genre result;
                Enum.TryParse(book.Genre, false, out result);
                if (!Enum.IsDefined(typeof(Genre), result))
                    genreControl.CurrentGenre = PAINApp.Genre.Poetry;
                else
                    genreControl.CurrentGenre = result;
            }
            else
            {
                RecordingDatePicker.Value = DateTime.Today;
                genreControl.CurrentGenre = PAINApp.Genre.Poetry;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TitleTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string title = TitleTextBox.Text;
                if (title == "")
                    throw new Exception("Title cannot be empty.");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                WarningSign.SetError(TitleTextBox, exception.Message);
            }
        }

        private void TitleTextBox_Validated(object sender, EventArgs e)
        {
            WarningSign.SetError(TitleTextBox, "");
        }

        private void AuthorTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string author = AuthorTextBox.Text;
                if (author == "")
                    throw new Exception("Author cannot be empty.");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                WarningSign.SetError(AuthorTextBox, exception.Message);
            }
        }


        private void AuthorTextBox_Validated(object sender, EventArgs e)
        {
            WarningSign.SetError(AuthorTextBox, "");
        }

        private void RecordingDatePicker_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime recordingDate = RecordingDatePicker.Value;
                if (recordingDate == null)
                    throw new Exception("You have to choose date.");
                if (DateTime.Compare(recordingDate, DateTime.Today) > 0)
                    throw new Exception("You cannot choose date from the future.");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                WarningSign.SetError(RecordingDatePicker, exception.Message);
            }
        }


        private void RecordingDatePicker_Validated(object sender, EventArgs e)
        {
            WarningSign.SetError(RecordingDatePicker, "");
        }


        private void genreControlChanged(string newGenre)
        {
            genreLabel.Text = genreControl.CurrentGenre.ToString();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

