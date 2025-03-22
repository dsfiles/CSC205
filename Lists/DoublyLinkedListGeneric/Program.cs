/*************************************************************
 * Doubly Linked List - Version 2.0 Generic Implementation
 * March 2025
 *************************************************************/

namespace DoublyLinkedListGeneric
{
    public class Node<T>
    {
        public Node<T> Next;
        public Node<T> Prev;
        public T Value;
        public Node(T data)
        {
            Value = data;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList<T>
    {
        public Node<T> head;
        public Node<T> tail;
        public Node<T> current; // This will have latest node
        public int Count;
        public DoublyLinkedList()
        { // Empty list does not have node, all pointers are set to null
            head = tail = current = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddStart(T data)
        {
            Node<T> newNode = new Node<T>(data);
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

        public void AddLast(T data)
        {
            var newNode = new Node<T>(data);
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
        public void InsertNode(T data)
        {
            var newNode = new Node<T>(data);
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
                Node<T> curr = head;
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
    }  // END of class DoublyLinkedList<T>

    public class Program
    {
        static void Main(string[] args)
        {
            var testList = new DoublyLinkedList<object>(); // testList can only store integers
            Console.WriteLine("Display the contents of a newly created list: ");
            testList.PrintList();

            Console.WriteLine($"Append 7 to the list");
            testList.AddLast(7);

            // Just want to show that a node can store any object (integers, strings, etc.)
            Console.WriteLine($"Append \"eight\" to the list");
            testList.AddLast("eight");

            Console.WriteLine($"Append 9 to the list");
            testList.AddLast(9);
            Console.WriteLine("Display the whole list:");
            testList.PrintList();

            Console.WriteLine($"Remove the last node: {testList.tail.Value}");
            testList.RemoveLast();
            testList.PrintList();

            Console.WriteLine($"Remove the first node: {testList.head.Value}");
            testList.RemoveStart();
            testList.PrintList();

            testList.AddStart(2);
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
    }
}
