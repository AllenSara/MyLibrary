using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    internal class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }

        public Book(int bookID, string title, string authors)
        {
            this.BookID = bookID;
            this.Title = title;
            this.Authors = authors;
        }
    }
}
