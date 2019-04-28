using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIApp
{
    public class Book
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public Book(long id, string title, string author, DateTime releaseDate, string genre)
        {
            Id = id;
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Genre = genre;
        }
    }
}
