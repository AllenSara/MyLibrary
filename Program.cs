// The following program was built to test efficency between dictionaries, lists, and trees.
// To test the timing of a data type, simply uncomment the relevant section by writing an inline comment (//) at the beginning of both the start (/*) and end (*/) block comment lines, and running the program.

using MyLibrary;
using System.Collections.Generic;

var dict = new Dictionary();
var tree = new Tree();
var list = new List();
int[] books = new int[] { 1, 21, 8976449, 79, 1566 }; //there is no book 8976449, book 79 is the 50th, book 1566 is the 500th (which is the last book based on the way the program runs with no user input on Insert(), see NOTE)
DateTimeOffset valBefore, valAfter;

//NOTE: currently all insert functions are set to insert 500 books (the first 500 lines of the excel (not including the header))
// However, an int can be used within the insert methods in order to specify a different number of lines, for example Insert(50) would insert the first 50 books.

//////////////////


/// timing for dictionary


///*
valBefore = (DateTimeOffset)DateTime.UtcNow;
dict.InsertDict();
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valInsertDict = valAfter - valBefore;
Console.WriteLine($"Total time to insert books into dictionary: {valInsertDict}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
foreach (int book in books)
    dict.SearchDict(book);
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valSearchDict = valAfter - valBefore;
Console.WriteLine($"Total time to search for some books in dictionary: {valSearchDict}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
dict.PrintDict();
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valPrintDict = valAfter - valBefore;
Console.WriteLine($"Total time to print dictionary: {valPrintDict}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
foreach (int book in books)
    dict.DeleteDict(book);
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valDeleteDict = valAfter - valBefore;
Console.WriteLine($"Total time to delete some books in dictionary: {valDeleteDict}");

//checks that books actually deleted
foreach (int book in books)
    dict.SearchDict(book);
//*/


/// timing for list


/*
valBefore = (DateTimeOffset)DateTime.UtcNow;
list.InsertList();
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valInsertList = valAfter - valBefore;
Console.WriteLine($"Total time to insert books into list: {valInsertList}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
foreach (int book in books)
    list.SearchList(book);
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valSearchList = valAfter - valBefore;
Console.WriteLine($"Total time to search for some books in list: {valSearchList}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
list.PrintList();
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valPrintList = valAfter - valBefore;
Console.WriteLine($"Total time to print list: {valPrintList}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
foreach (int book in books)
    list.DeleteList(book);
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valDeleteList = valAfter - valBefore;
Console.WriteLine($"Total time to delete some books in list: {valDeleteList}");

//checks that books actually deleted
foreach (int book in books)
    list.SearchList(book);
*/


///timing for tree


/*
valBefore = (DateTimeOffset)DateTime.UtcNow;
tree.InsertTree();
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valInsertTree = valAfter - valBefore;
Console.WriteLine($"Total time to insert books into tree: {valInsertTree}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
foreach (int book in books)
    tree.SearchTree(book);
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valSearchTree = valAfter - valBefore;
Console.WriteLine($"Total time to search for some books in tree: {valSearchTree}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
tree.PrintMyTree();
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valPrintTree = valAfter - valBefore;
Console.WriteLine($"Total time to print tree: {valPrintTree}");

valBefore = (DateTimeOffset)DateTime.UtcNow;
foreach (int book in books)
    tree.DeleteTree(book);
valAfter = (DateTimeOffset)DateTime.UtcNow;
TimeSpan valDeleteTree = valAfter - valBefore;
Console.WriteLine($"Total time to delete some books in tree: {valDeleteTree}");

//checks that books actually deleted
foreach (int book in books)
    tree.SearchTree(book);
*/


/////////////////

// The code below was written in an attempt to get a more accuarte idea of timing by running each action 500 times, taking off the first and last 50 times, and then getting an average from the middle 400 values.
// Here it is only presented for the Insert Dictionary action, but a similar process can be used on the rest of the actions, with relevant modifications. 
// While this method did result in slightly less extreme differences when running the program multiple times, the averages can still differ in timing up to about 0.001. 

/*
TimeSpan valInsertDict;
List<TimeSpan> timeSpans = new();
TimeSpan total = TimeSpan.Zero;
for (int i= 0; i<500; i++)
{
    valBefore = (DateTimeOffset)DateTime.UtcNow;
    dict.InsertDict();
    valAfter = (DateTimeOffset)DateTime.UtcNow;
    valInsertDict = valAfter - valBefore;
    timeSpans.Add(valInsertDict);
    dict.DeleteWholeDict(); // without emptying the dictionary, the books will not be able to be reinserted as the dictionary cannot insert two books with identical IDs
}
timeSpans.Sort();
List<TimeSpan> centralTimeSpans = timeSpans.GetRange(49, 400);
centralTimeSpans.ForEach(time => total += time);
Console.WriteLine($"Total average time to insert books into dictionary: {total / 400}");
*/