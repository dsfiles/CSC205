/*************************************************************
 * Week 13 Quiz
 * 2. You will add the following methods to the existing doubly linked list code below:
   https://raw.githubusercontent.com/dsfiles/CSC205/refs/heads/master/Lists/DoublyLinkedListGeneric/Program.cs
   To simplify the program, use integer (int) for the generic type T to test your methods.
   Study the doubly linked list implementation above before the exam. 

 * Doubly Linked List - Version 2.0 Generic Implementation
 * March 2025
 *************************************************************/

using System.Text;

namespace Week13
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

        // 1) Write a method Reverse() that reverses the order of elements in a doubly linked list.
        public void Reverse()
        {
            // your code is here
            if (!IsEmpty())
            {
                Node<T> curr = head, curr2, temp;
                while (curr != null)
                {
                    curr2 = curr.Next; // reember the next node if not null
                    temp = curr.Next;
                    curr.Next = curr.Prev;
                    curr.Prev = temp;
                    curr = curr2;
                }
                temp = tail;
                tail = head;
                head = temp;
            }
        }

        // 2) Delete all the nodes that contain 'data'. 
        public void DeleteNodes(T data)
        {
            // your code is here
            if (!IsEmpty())
            {
                // remove the first and possibly follwing nodes if their value is equal to data
                if (head.Value.Equals(data))
                {
                    RemoveStart();
                }
                // remove nodes in the middle
                Node<T> curr = head;
                while (curr.Next != null)
                {
                    if (curr.Value.Equals(data))
                    {
                        curr.Prev.Next = curr.Next;
                        curr.Next.Prev = curr.Prev;
                        current = curr.Next;
                    }
                    curr = curr.Next;
                }
                // remove the last node if its value is equal to data
                if (curr.Value.Equals(data))
                {
                    RemoveLast();
                }
            }
        }

        // 3) Remove all the duplicate nodes that contain the same value(data).
        public void RemoveDuplicates()
        {
            // your code is here
            if (!IsEmpty())
            {
                Node<T> curr = head, curr2;
                while (curr.Next != null)
                {
                    curr2 = curr.Next;
                    while (curr2.Next != null)
                    {
                        if (curr2.Value.Equals(curr.Value))
                        {
                            curr2.Prev.Next = curr2.Next;
                            curr2.Next.Prev = curr2.Prev;
                        }
                        curr2 = curr2.Next;
                    }
                    // remove the last node if its value is equal to curr.Value
                    if (curr2.Value.Equals(curr.Value))
                    {
                        RemoveLast();
                    }
                    curr = curr.Next;
                }
            }
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
        { // new
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

            Console.WriteLine("Insert 5, 6, 5, 6, 7 to the list:");
            testList.InsertNode(5);
            testList.InsertNode(6);
            testList.InsertNode(5);
            testList.InsertNode(6);
            testList.InsertNode(7);

            Console.WriteLine(testList);
            Console.WriteLine("head node is " + testList.head.Value);
            Console.WriteLine("tail node is " + testList.tail.Value);
            Console.WriteLine("curr node is " + testList.current.Value);
            Console.WriteLine("Final count of nodes is " + testList.Count);

            // Week 13 quiz
            Console.WriteLine("\nWeek 13 quiz testing:");
            Console.WriteLine("Reverse the list:");
            testList.Reverse();
            Console.WriteLine(testList);

            Console.WriteLine("Remove nodes with value of 5");
            testList.DeleteNodes(5);
            Console.WriteLine(testList);

            Console.WriteLine("Remove duplicates");
            testList.RemoveDuplicates();
            Console.WriteLine(testList);
        }
    }
}
