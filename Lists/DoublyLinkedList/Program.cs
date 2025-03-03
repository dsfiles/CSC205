/*************************************************************
 * Doubly Linked List - Version 1.0 Non-Generic Implementation
 * March 2025
 *************************************************************/

using System;

namespace LinkedList
{
    public class Node
    {
        public Node Next;
        public Node Prev;
        public object Value;
        public Node(object obj)
        {
            Value = obj;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList
    {
        public Node head;
        public Node tail;
        public Node current; // This will have latest node
        public int Count;
        public DoublyLinkedList()
        {
            // Empty list does not have node, all pointers are set to null
            head = tail = current = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddStart(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode.Prev = null;
            }
            else
            {
                newNode.Next = head;
                newNode.Prev = null;
                head.Prev = newNode;
                head = current = newNode;
            }
            Count++;
        }

        public void RemoveStart()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            else if (head.Next == null) // Only one node in the list
            {
                head = tail = current = null;
            }
            else
            {
                head = current = head.Next;
                head.Prev = null;
            }
            Count--;
        }

        public void AddLast(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode.Prev = null;
            }
            else
            {
                newNode.Next = null;
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = current = newNode;
            }
            Count++;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            else if (head.Next == null) // Only one node in the list
            {
                head = tail = current = null;
            }
            else
            {
                tail = current = tail.Prev;
                tail.Next = null;
            }
            Count--;
        }


        // A new node is inserted after the 'current' node
        public void InsertNode(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode.Prev = null;
                Count++;
            }
            else if (current == tail)
            { // If the 'current' node is the last one
                AddLast(data);
            }
            else
            {
                newNode.Next = current.Next;
                newNode.Prev = current;
                current.Next = current.Next.Prev = newNode;
                current = current.Next;
                Count++;
            }
        }

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty list!");
            }
            else
            {
                Console.Write("--- Head");
                Node curr = head;
                while (curr != null) // Advance the pointer
                {
                    if (curr == current)
                    { // Mark the 'current' node with <= =>
                        Console.Write(" <=");
                        Console.Write(curr.Value);
                        Console.Write("=> ");
                        curr = curr.Next;
                    }
                    else
                    {
                        Console.Write(" <-");
                        Console.Write(curr.Value);
                        Console.Write("-> ");
                        curr = curr.Next;
                    }
                }
                Console.WriteLine("Tail ---");
            }
        }
    } // END of class DoublyLinkedList

    public class DoublyLinkedListTest
    {
        static void Main(string[] args)
        {
            DoublyLinkedList testList = new DoublyLinkedList();
            Console.WriteLine("Display the contents of a newly created list: ");
            testList.PrintList();

            Console.WriteLine($"Append {789} to the list");
            testList.AddLast(789);

            Console.WriteLine($"Append 'Bob' to the list");
            testList.AddLast("Bob");

            Console.WriteLine($"Append 'John' to the list");
            testList.AddLast("John");
            Console.WriteLine("Display the whole list:");
            testList.PrintList();

            Console.WriteLine($"Remove the last node: {testList.tail.Value}");
            testList.RemoveLast();
            testList.PrintList();

            Console.WriteLine($"Remove the first node: {testList.head.Value}");
            testList.RemoveStart();
            testList.PrintList();

            testList.AddStart("Abby");
            Console.WriteLine($"Add {testList.current.Value} to the front of list");
            testList.PrintList();

            Console.WriteLine($"Remove the last node: {testList.tail.Value}");
            testList.RemoveLast();
            testList.PrintList();

            Console.WriteLine("Insert 5, 6, 7 to the list:");
            testList.InsertNode(5);
            testList.InsertNode(6);
            testList.InsertNode(7);
            testList.PrintList();
            Console.WriteLine("head node is " + testList.head.Value);
            Console.WriteLine("tail node is " + testList.tail.Value);
            Console.WriteLine("curr node is " + testList.current.Value);
            Console.WriteLine("Final count of nodes is " + testList.Count);
        }
    } // END of class DoublyLinkedListTest
}