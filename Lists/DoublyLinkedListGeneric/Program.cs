/*************************************************************
 * Doubly Linked List - Version 2.0 Generic Implementation
 * March 2025
 *************************************************************/

using System.Text;

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (IsEmpty())
            {
                sb.Append("Empty list!");
            }
            else
            {
                sb.Append("--- Head");
                Node<T> curr = head;
                while (curr != null) // Advance the pointer
                {
                    if (curr == current)
                    { // Mark the 'current' node with <= =>
                        sb.Append(" <=");
                        sb.Append(curr.Value);
                        sb.Append("=> ");
                        curr = curr.Next;
                    }
                    else
                    {
                        sb.Append(" <-");
                        sb.Append(curr.Value);
                        sb.Append("-> ");
                        curr = curr.Next;
                    }
                }
                sb.Append("Tail ---");
            }
            return sb.ToString();
        }
    }  // END of class DoublyLinkedList<T>

    public class Program
    {
        static void Main(string[] args)
        {
            var testList = new DoublyLinkedList<int>(); // testList can only store integers
            Console.WriteLine("Display the contents of a newly created list: ");
            Console.WriteLine(testList);

            Console.WriteLine($"Append 7 to the list");
            testList.AddLast(7);

            Console.WriteLine($"Append 8 to the list");
            testList.AddLast(8);

            Console.WriteLine($"Append 9 to the list");
            testList.AddLast(9);
            Console.WriteLine("Display the whole list:");
            Console.WriteLine(testList);

            Console.WriteLine($"Remove the last node: {testList.tail.Value}");
            testList.RemoveLast();
            Console.WriteLine(testList);

            Console.WriteLine($"Remove the first node: {testList.head.Value}");
            testList.RemoveStart();
            Console.WriteLine(testList);

            testList.AddStart(2);
            Console.WriteLine($"Add {testList.current.Value} to the front of list");
            Console.WriteLine(testList);

            Console.WriteLine($"Remove the last node: {testList.tail.Value}");
            testList.RemoveLast();
            Console.WriteLine(testList);

            Console.WriteLine("Insert 5, 6, 7 to the list:");
            testList.InsertNode(5);
            testList.InsertNode(6);
            testList.InsertNode(7);
            Console.WriteLine(testList);
            Console.WriteLine("head node is " + testList.head.Value);
            Console.WriteLine("tail node is " + testList.tail.Value);
            Console.WriteLine("curr node is " + testList.current.Value);
            Console.WriteLine("Final count of nodes is " + testList.Count);
        }
    }
}
