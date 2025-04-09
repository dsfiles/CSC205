/*************************************************************
 * CSC205 Assignment Week 10 - Implementation of
 * Testing of Circular Doubly-Linked List and Sorted Doubly-Linked List
 * April 2025
 *************************************************************/

namespace Week10;
public class Program
{
    static void Main(string[] args)
    {
        var playList = new CircularLinkedList();
        Console.WriteLine("Display the contents of a newly created play list: ");
        Console.WriteLine(playList);

        playList.AddStart("music1");
        Console.WriteLine($"Add {playList.current.Value} to the front of list");
        Console.WriteLine(playList);
        Console.WriteLine($"size of list is {playList.Count}");

        Console.WriteLine("\nInsert music2, music3, music4 to the list:");
        playList.InsertNode("music2");
        playList.InsertNode("music3");
        playList.InsertNode("music4");
        Console.WriteLine(playList);
        Console.WriteLine("head node is " + playList.head.Value);
        Console.WriteLine("curr node is " + playList.current.Value);
        Console.WriteLine("Final count of nodes is " + playList.Count);

        Console.WriteLine($"\nRemove the first node: {playList.head.Value}");
        playList.RemoveStart();
        Console.WriteLine(playList);

        Console.WriteLine($"\nMove the \"current\" pointer forward one node");
        playList.MoveForward();
        Console.WriteLine(playList);

        Console.WriteLine("\nTesting sorted linked list!");

        var sortedList = new SortedLinkedList<int>();
        Console.WriteLine("Display the contents of a newly created list: ");
        Console.WriteLine(sortedList);

        //Console.WriteLine($"Remove the first node: {sortedList.head.Value}");
        //sortedList.RemoveStart();
        //Console.WriteLine(sortedList);

        //sortedList.AddStart(2);
        //Console.WriteLine($"Add {sortedList.current.Value} to the front of list");
        //Console.WriteLine(sortedList);

        //Console.WriteLine($"Remove the last node: {sortedList.tail.Value}");
        //sortedList.RemoveLast();
        //Console.WriteLine(sortedList);

        Console.WriteLine("Insert 6, 3, 7, 1 to the list:");
        sortedList.InsertNode(6);
        sortedList.InsertNode(3);
        sortedList.InsertNode(7);
        sortedList.InsertNode(1);
        Console.WriteLine(sortedList);
        Console.WriteLine("head node is " + sortedList.head.Value);
        Console.WriteLine("tail node is " + sortedList.tail.Value);
        Console.WriteLine("curr node is " + sortedList.current.Value);
        Console.WriteLine("Final count of nodes is " + sortedList.Count);

        Console.WriteLine("\nRemove the first (min) node");
        sortedList.RemoveMin();
        Console.WriteLine(sortedList);

        Console.WriteLine("\nRemove the last (max) node");
        sortedList.RemoveMax();
        Console.WriteLine(sortedList);
    }
} // END of Program class