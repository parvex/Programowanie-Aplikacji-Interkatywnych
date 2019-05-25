using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAINApp
{
    public class Book    
    {       
        public string Title
        { get; set; }

        public string Author
        { get; set; }

        public DateTime RecordingDate
        { get; set; }

        public string Genre
        { get; set; }

        public Book(string Title, string Author, DateTime RecordingDate, string Genre)
        {
            this.Title = Title;
            this.Author = Author;
            this.RecordingDate = RecordingDate;
            this.Genre = Genre;
        }
    }
}
