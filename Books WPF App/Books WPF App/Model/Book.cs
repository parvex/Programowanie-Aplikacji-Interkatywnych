using System;
using System.ComponentModel;

namespace Books.Model
{
    class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string title;
        private string author;
        private DateTime releaseDate;
        private string genre;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (author != value)
                {
                    author = value;
                    RaisePropertyChanged("Author");
                }
            }
        }

        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }
            set
            {
                if (releaseDate != value)
                {
                    releaseDate = value;
                    RaisePropertyChanged("ReleaseDate");
                }
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                if (genre != value)
                {
                    genre = value;
                    RaisePropertyChanged("Genre");
                }
            }
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void ResetValues()
        {
            title = null;
            author = null;
            releaseDate = DateTime.MinValue;
            genre = null;
        }

        public bool IsValid()
        {
            return title != null && author != null && releaseDate != DateTime.MinValue && genre != null;
        }
    }
}
