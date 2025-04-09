/*************************************************************
 * CSC205 Assignment - Week 10
 * 1) Implement a circular doubly linked list data structure using the following doubly linked list code:
 *    https://github.com/dsfiles/CSC205/tree/master/Lists/DoublyLinkedList
 * 2) Write a simple application that uses your circular doubly linked list.
 * 
 * Circular Doubly-Linked List - Version 1.0 Non-Generic Implementation
 * April 2025
 *************************************************************/

namespace Week10;

using System;
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

public class CircularLinkedList
{
    public Node head;
    //public Node tail; not needed
    public Node current; // This will have latest node
    public int Count;
    public CircularLinkedList()
    {
        // Empty list does not have node, all pointers are set to null
        head = current = null;
        Count = 0;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    // Adds a new node at the beginning of list
    public void AddStart(object data)
    {
        Node newNode = new Node(data);
        if (IsEmpty())
        {
            head = current = newNode;
            newNode.Next = newNode.Prev = newNode;
        }
        else
        {
            newNode.Next = head;
            newNode.Prev = head.Prev;
            head.Prev.Next = newNode;
            head.Prev = newNode;
            head = current = newNode;
        }
        Count++;
    }

    // Removes the head node
    public void RemoveStart()
    {
        if (IsEmpty())
        {
            throw new Exception("Can't remove a node from an empty list!");
        }
        else if (Count == 1) // Only one node in the list
        {
            head = current = null;
        }
        else
        {
            head.Next.Prev = head.Prev;
            head.Prev.Next = head.Next;
            head = current = head.Next;
        }
        Count--;
    }

    // Inserts a new node after the 'current' node
    public void InsertNode(object data)
    {
        Node newNode = new Node(data);
        if (IsEmpty())
        {
            head = current = newNode;
            newNode.Next = newNode.Prev = newNode;
            Count++;
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


    // Advances the "current" pointer to the next node
    public void MoveForward()
    {
        if (!IsEmpty())
        {
            current = current.Next;
        }
    }

    public void MoveBackward()
    {
        if (!IsEmpty())
        {
            current = current.Prev;
        }
    }

    public override string ToString()
    {
        if (IsEmpty())
        {
            return "~~ empty list ~";
        }
        else if (Count == 1)
        {
            return $"--> head <= {head.Value} =>";
        }
        else
        { // Count > 1
            string result = "--> head";
            Node curr = head;
            do
            {
                if (curr == current)
                { // Mark the 'current' node with <= =>
                    result += $" <= {curr.Value} => ";
                    curr = curr.Next;
                }
                else
                {
                    result += $" <- {curr.Value} -> ";
                    curr = curr.Next;
                }
            } while (curr != head); // Prints the rest of nodes
            return result;
        }
    }

} // END of class CircularLinkedList
