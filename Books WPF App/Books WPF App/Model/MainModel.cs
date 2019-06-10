using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Books.Model
{
    class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Book> Books
        {
            get;
            set;
        }

        
        static MainModel() {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            books.Add(new Book { Title = "Sillmarilion", Author = "J.R.R Tolkien", ReleaseDate = (new DateTime(2005, 1, 15)), Genre = "Fantasy" });
            books.Add(new Book { Title = "Dzieci z Bullerbyn", Author = "Astrid Lindgren", ReleaseDate = new DateTime(1995, 8, 7), Genre = "Dzieci" });
            Books = books;
        }
    }
}
