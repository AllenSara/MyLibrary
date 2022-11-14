using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    internal class Tree
    {
        public NodeTree<Book>? Root;

        public void InsertNode(NodeTree<Book> node) //used in InsertTree() to insert a node
        {
            if (Root == null) { Root = node; }
            else
            {
                NodeTree<Book> current = Root;
                while (current != null)
                {
                    NodeTree<Book> left = current.Left;
                    NodeTree<Book> right = current.Right;
                    if (left == null && right == null)
                    {
                        node.Parent = current;
                        if (node.Value.BookID > current.Value.BookID)
                            current.Right = node;
                        else
                            current.Left = node;
                        return;
                    }
                    else if (left == null)
                    {
                        if (node.Value.BookID > current.Value.BookID)
                            current = right;
                        else
                        {
                            node.Parent = current;
                            current.Left = node;
                            return;
                        }
                    }
                    else if (right == null)
                    {
                        if (node.Value.BookID < current.Value.BookID)
                            current = left;
                        else
                        {
                            node.Parent = current;
                            current.Right = node;
                            return;
                        }
                    }
                    else
                    {
                        if (node.Value.BookID < current.Value.BookID)
                            current = left;
                        else
                            current = right;
                    }
                }
            }
        }

        public NodeTree<Book> FindNode(int id) //used in SearchTree() and DeleteTree() to find the node based on id
        {
            if (Root == null)
            {
                Console.WriteLine("Sorry, there are currently no books in the library.");
                return null;
            }
            else
            {
                NodeTree<Book> current = Root;
                while (current != null)
                {
                    if (id == current.Value.BookID) { return current; }
                    else if (id < current.Value.BookID) { current = current.Left; }
                    else { current = current.Right; }
                }
                return current;
            }
        }

        public void PrintTree(NodeTree<Book> root) //used in PrintMyTree() in order to enable recursive use
        {
            NodeTree<Book> left = root.Left;
            NodeTree<Book> right = root.Right;
            if (root.Value.Title != null)
            {
                Console.WriteLine("Title: " + root.Value.Title + "\nAuthor: " + root.Value.Authors + "\nID: " + root.Value.BookID + "\n");
            }
            if (right != null)
            {
                PrintTree(root.Right);
            }
            if (left != null)
            {
                PrintTree(root.Left);
            }
        }

        public void GetTotal() //used in PrintMyTree() to print total amount of books after printing details of all books
        {
            Console.WriteLine($"Total books in library: {Total(Root)}");
        }
        public int Total(NodeTree<Book> root) //used in GetTotal() in order to enable recursive use
        {
            if (root == null)
                return 0;
            return 1 + Total(root.Left) + Total(root.Right);
        }

        public NodeTree<Book> GetMin(NodeTree<Book> node)//used in DeleteTree() when a node has two children
        {
            if (node.Left == null)
                return node;
            return GetMin(node.Left);
        }

        public void InsertTree(int rowsToInsert = 500)
        {
            int counter = 0;
            var c = new Csv();
            CsvReader csv = c.GetCSV();
            csv.Read();
            csv.ReadHeader();
            NodeTree<Book> node;
            while (csv.Read() && rowsToInsert > counter)
            {
                node = new NodeTree<Book>(new Book(csv.GetField<int>("bookID"), csv.GetField("title"), csv.GetField("authors")));
                //Console.WriteLine($"The book {node.Value.Title} was succesfully added to the library!"); //commented due to excessive added time when adding large quantities of books
                InsertNode(node);
                counter++;
            }
        }

        public NodeTree<Book> SearchTree(int bookID)
        {
            NodeTree<Book> node = FindNode(bookID);
            if (node != null)
            {
                Console.WriteLine($"Title: {node.Value.Title}\nAuthor: {node.Value.Authors}\nID: {bookID}");
                return node;
            }
            else
            {
                Console.WriteLine("Sorry, we cannot find a book under this ID.");
                return null;
            }
        }

        public void PrintMyTree()
        {
            NodeTree<Book> root = Root;
            if (root != null)
            {
                PrintTree(root);
                GetTotal();
            }
            else
                Console.WriteLine("Sorry, there are currently no books in the library.");
        }

        public void DeleteTree(int bookID)
        {
            NodeTree<Book> node = FindNode(bookID);
            if (node == null)
            {
                Console.WriteLine("Sorry, we cannot find a book under this ID.");
                return;
            }
            else
            {
                NodeTree<Book> parent = node.Parent;
                NodeTree<Book> left = node.Left;
                NodeTree<Book> right = node.Right;
                if (parent == null) //node is root
                {
                    if (left != null && right != null)
                        left.Parent = right;
                    else if (right != null)
                        Root = right;
                    else if (left != null)
                        Root = left;
                    else
                        Root = null;
                }
                else if (right == null && left == null) //node has no children
                {
                    if (parent.Value.BookID > node.Value.BookID)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
                else if (right == null || left == null) //node has one child
                {
                    if (parent.Value.BookID > node.Value.BookID)
                        parent.Left = node.Left;
                    else
                        parent.Right = node.Right;
                }
                else //node has two children
                {
                    NodeTree<Book> min = GetMin(right);
                    if (parent.Value.BookID < node.Value.BookID)
                        parent.Right = min;
                    else
                        parent.Left = min;
                }
                Console.WriteLine($"Book number {bookID} has successfully been removed from the library.");
            }
        }
    }
}
