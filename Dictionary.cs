using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;


namespace MyLibrary
{
    internal class Dictionary
    {
        public Dictionary<int, Book> MyDict { get; set; } = new();
        public void InsertDict(int rowsToInsert = 500)
        {
            int counter = 0;
            var c = new Csv();
            CsvReader csv = c.GetCSV();
            csv.Read();
            csv.ReadHeader();
            while (csv.Read() && rowsToInsert > counter)
            {
                Book book = new(csv.GetField<int>("bookID"), csv.GetField("title"), csv.GetField("authors"));
                MyDict.Add(book.BookID, book);
                //Console.WriteLine($"The book {book.Title} was succesfully added to the library!"); //commented due to excessive added time when adding large quantities of books
                counter++;
            }
        }
        public Book SearchDict(int bookID)
        {
            if (MyDict.ContainsKey(bookID))
            {
                Console.WriteLine($"Title: {MyDict[bookID].Title}\nAuthor: {MyDict[bookID].Authors}\nID: {bookID}");
                return MyDict[bookID];
            }
            else
            {
                Console.WriteLine("Sorry, we cannot find a book under this ID.");
                return null;
            }
        }
        public void PrintDict()
        {
            if (MyDict is null)
            {
                Console.WriteLine("Sorry, there are currently no books in the library."); return;
            }
            else
            {
                MyDict.ToList().ForEach(book => Console.WriteLine($"Title: {book.Value.Title}\nAuthor: {book.Value.Authors}\nID: {book.Value.BookID}\n"));
                Console.WriteLine($"Total books in library: {MyDict.Count}");
            }
        }
        public void DeleteDict(int bookID)
        {
            if (MyDict.ContainsKey(bookID))
            {
                MyDict.Remove(bookID);
                Console.WriteLine($"Book number {bookID} has successfully been removed from the library.");
            }
            else
                Console.WriteLine("Sorry, we cannot find a book under this ID.");
        }
        public void DeleteWholeDict()
        {
            MyDict.Clear();
        }
    }
}
