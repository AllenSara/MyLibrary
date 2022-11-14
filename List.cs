using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    internal class List
    {
        NodeList<Book>? First;
        public void InsertList(int rowsToInsert = 500)
        {
            int counter = 1; //intialized at one due to intialization of First as seen below in line 21
            var c = new Csv();
            CsvReader csv = c.GetCSV();
            csv.Read();
            csv.ReadHeader();
            csv.Read();
            First = new(new Book(csv.GetField<int>("bookID"), csv.GetField("title"), csv.GetField("authors")));
            NodeList<Book> last = First;
            while (csv.Read() && rowsToInsert > counter)
            {
                last.Next = new NodeList<Book>(new Book(csv.GetField<int>("bookID"), csv.GetField("title"), csv.GetField("authors")));
                //Console.WriteLine($"The book {last.Next.Value.Title} was succesfully added to the library!"); //commented due to excessive added time when adding large quantities of books
                last = last.Next;
                counter++;
            }
        }

        public NodeList<Book> SearchList(int bookID)
        {
            NodeList<Book> last = First;
            while (last != null)
            {
                if (last.Value.BookID == bookID)
                {
                    Console.WriteLine($"Title: {last.Value.Title}\nAuthor: {last.Value.Authors}\nID: {bookID}");
                    return last;
                }
                last = last.Next;
            }
            if (last == null)
                Console.WriteLine("Sorry, we cannot find a book under this ID.");
            return null;
        }

        public void PrintList()
        {
            int counter = 0;
            NodeList<Book> last = First;
            if (last == null)
            {
                Console.WriteLine("Sorry, there are currently no books in the library."); return;
            }
            while (last != null)
            {
                Console.WriteLine($"Title: {last.Value.Title}\nAuthor: {last.Value.Authors}\nID: {last.Value.BookID}\n");
                last = last.Next;
                counter++;
            }
            Console.WriteLine($"Total books in library: {counter}");
        }

        public void DeleteList(int bookID)
        {
            NodeList<Book> last = First;
            NodeList<Book> next;
            if (First.Value.BookID == bookID)
            {
                next = last.Next;
                First = next;
                First.Next = next.Next;
                Console.WriteLine($"Book number {bookID} has successfully been removed from the library.");
                return;
            }
            while (last.Next != null)
            {
                next = last.Next;
                if (next.Value.BookID == bookID)
                {
                    last.Next = next.Next;
                    Console.WriteLine($"Book number {bookID} has successfully been removed from the library.");
                    return;
                }
                last = last.Next;
            }
            if (last.Next == null)
                Console.WriteLine("Sorry, we cannot find a book under this ID.");
        }
    }
}
