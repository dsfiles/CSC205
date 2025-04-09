/*************************************************************
 * CSC205 Assignment Week 10 - Implementation of a Sorted Doubly-Linked List
 * April 2025
 *************************************************************/
namespace Week10;

using System.Text; // for StringBuilder

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

public class SortedLinkedList<T> where T : IComparable<T>
{
    public Node<T> head;
    public Node<T> tail;
    public Node<T> current; // This will have latest node
    public int Count;
    public SortedLinkedList()
    { // Empty list does not have node, all pointers are set to null
        head = tail = current = null;
        Count = 0;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }
    
    public void RemoveMin()
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

    public void RemoveMax()
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

    // Inserts a new node at the correct position
    public void InsertNode(T data)
    {
        var newNode = new Node<T>(data);
        if (IsEmpty())
        {
            head = tail = current = newNode;
            newNode.Next = newNode.Prev = null;
            Count++;
        }
        // If the new node’s value is smaller than or equal to the head’s value, inserts it at the beginning. 
        else if (data.CompareTo(head.Value) <= 0)
        {
            head.Prev = newNode;
            newNode.Next = head;
            head = current = newNode;
            Count++;
        }
        // If the new node’s value is greater than or equal to the tail’s value, inserts it at the end. 
        else if (data.CompareTo(tail.Value) >= 0)
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = current = newNode;
            Count++;
        }
        else // Inserts the node in the middle
        {
            Node<T> curr = head;
            while (data.CompareTo(curr.Value) > 0 && curr != tail)
            {
                curr = curr.Next;
            }
            newNode.Next = curr;
            newNode.Prev = curr.Prev;
            curr.Prev.Next = newNode;
            curr.Prev = newNode;
            current = newNode;
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
}  // END of class SortedLinkedList<T>