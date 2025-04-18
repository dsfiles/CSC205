﻿namespace BinarySearchTreeV2;

/* 
 * Binary Search Tree - A C# Implementation
 * DisplayTree2D() nicely prints a BST in Console
 * Last update 12/2024
 */

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var bst = new BinarySearchTree();
        /* Let us create following BST
             5
            / \
           3   7
          / \ / \
         2  4 6  8  */
        Console.WriteLine("Let's create a new BST:");
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(2);
        bst.Insert(4);
        bst.Insert(7);
        bst.Insert(6);
        bst.Insert(8);
        Console.WriteLine("Node count: " + bst.Count);
        bst.DisplayTree2D();

        ////Create a BST of 20(or less) random numbers(0~99)
        //var rand = new Random();
        //for (int i = 0; i < 20; i++)
        //{
        //    bst.Insert(rand.Next(0, 100));
        //}

        Console.WriteLine("\nInorder traversal:");
        bst.Inorder();

        Console.WriteLine("\nAfter deleting node 3:");
        bst.DeleteNode(3);
        bst.DisplayTree2D();

        Console.WriteLine("\nLet's insert 3 back into the tree (see the difference from the original tree):");
        bst.Insert(3);
        bst.DisplayTree2D();

        Console.WriteLine("\nAfter deleting node 5:");
        bst.DeleteNode(5);
        bst.DisplayTree2D();

    }
}

// Defind a node
public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node Parent { get; set; }
    public Node(int data)
    {
        Key = data;
        Parent = Right = Left = null; // Explicitly set these pointers to null
    }
}

// A class defined specifically for method DisplayTree2D()
public class NodeInfo
{
    public Node node;
    public string text;
    public int StartPos;
    public int Size { get { return text.Length; } }
    public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
    public NodeInfo Parent, Left, Right;
}

public class BinarySearchTree
{
    private Node _root;
    public Node Root { get { return _root; } }
    public int Count { get; set; }
    public BinarySearchTree()
    {
        _root = null;
    }

    public void Insert(int data)
    {
        Node ptr = _root; // Always start from the root node
        // If the tree is empty, make new node the root node
        if (ptr == null)
        {
            _root = new Node(data);
            Count++;
            return;
        }

        // Otherwise, move down the tree
        while (data < ptr.Key && ptr.Left != null || data > ptr.Key && ptr.Right != null)
        {
            if (data < ptr.Key)
                ptr = ptr.Left;
            else
                ptr = ptr.Right;
        }
        if (data < ptr.Key) // Make new node left child
        {
            ptr.Left = new Node(data);
            ptr.Left.Parent = ptr;
            Count++;
        }
        else if (data > ptr.Key) // Make new node right child
        {
            ptr.Right = new Node(data);
            ptr.Right.Parent = ptr;
            Count++;
        }
        else
        {
            Console.WriteLine($"Can't insert a duplicated integer - {data}");
        }
    }

    public void Inorder()
    {
        Inorder(_root);
    }
    private void Inorder(Node ptr)
    {
        if (ptr != null)
        {
            Inorder(ptr.Left);
            Console.Write("Node : " + ptr.Key + " , ");
            if (ptr.Parent == null)
                Console.WriteLine("Parent : NULL");
            else
                Console.WriteLine("Parent : " + ptr.Parent.Key);
            Inorder(ptr.Right);
        }
    }

    public int Predecessor(Node ptr)
    {
        Node curr = ptr.Left;
        while (curr.Right != null)
        {
            curr = curr.Right;
        }
        return curr.Key;
    }

    public int Successor(Node ptr)
    {
        Node curr = ptr.Right;
        while (curr.Left != null)
        {
            curr = curr.Left;
        }
        return curr.Key;
    }

    public bool Search(int data)
    {
        throw new NotImplementedException("Not ready yet");
    }

    public bool IsLeaf(Node ptr)
    {
        return ptr.Left == null && ptr.Right == null;
    }

    public void DeleteNode(int data)
    {
        DeleteNode(Root, data);
    }
    private void DeleteNode(Node ptr, int data)
    {
        if (ptr == null)
        {
            Console.WriteLine("No node is deleted!");
            return;
        }
        if (data < ptr.Key)
            DeleteNode(ptr.Left, data); // Delete the node in the left subtree
        else if (data > ptr.Key)
            DeleteNode(ptr.Right, data); // Delete the node in the right subtree
        else // Found the node to be deleted
        {
            if (IsLeaf(ptr)) // If the node is leaf
            {
                if (ptr == ptr.Parent.Left)
                    ptr.Parent.Left = null;
                else
                    ptr.Parent.Right = null;
                return;
            }
            // Node with a left child only
            else if (ptr.Right == null)
            { // Not a leaf node and does not have a right child
                ptr = ptr.Left;
                return;
            }
            // Node with a right child only
            else if (ptr.Left == null)
            { // Not a leaf node and does not have a left child
                ptr = ptr.Right;
                return;
            }
            else // Node with both two children
            {
                int succ = Successor(ptr);
                ptr.Key = succ;
                // Delete the inorder successor
                DeleteNode(ptr.Right, succ);
            }
        }
    }

    // A simple in-order display of all nodes 
    private void DisplayTree(Node ptr)
    {
        if (ptr == null)
        {
            return;
        }
        DisplayTree(ptr.Left);
        System.Console.Write(ptr.Key + " ");
        DisplayTree(ptr.Right);
    }
    public void DisplayTree()
    {
        DisplayTree(Root);
    }

    /* 
     * Display of BST in a console window
     * Source of the following code:
     * https://stackoverflow.com/questions/36311991/c-sharp-display-a-binary-search-tree-in-console
     */
    public void DisplayTree2D()
    {
        Node root = _root;
        string textFormat = "0";
        int spacing = 1;
        int topMargin = 0;
        int leftMargin = 1;
        if (root == null) return;
        int rootTop = Console.CursorTop + topMargin;
        var last = new List<NodeInfo>();
        var next = root;
        for (int level = 0; next != null; level++)
        {
            var item = new NodeInfo { node = next, text = next.Key.ToString(textFormat) };
            if (level < last.Count)
            {
                item.StartPos = last[level].EndPos + spacing;
                last[level] = item;
            }
            else
            {
                item.StartPos = leftMargin;
                last.Add(item);
            }
            if (level > 0)
            {
                item.Parent = last[level - 1];
                if (next == item.Parent.node.Left)
                {
                    item.Parent.Left = item;
                    item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                }
                else
                {
                    item.Parent.Right = item;
                    item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                }
            }
            next = next.Left ?? next.Right;
            for (; next == null; item = item.Parent)
            {
                int top = rootTop + 2 * level;
                Print(item.text, top, item.StartPos);
                if (item.Left != null)
                {
                    Print("/", top + 1, item.Left.EndPos);
                    Print("_", top, item.Left.EndPos + 1, item.StartPos);
                }
                if (item.Right != null)
                {
                    Print("_", top, item.EndPos, item.Right.StartPos - 1);
                    Print("\\", top + 1, item.Right.StartPos - 1);
                }
                if (--level < 0) break;
                if (item == item.Parent.Left)
                {
                    item.Parent.StartPos = item.EndPos + 1;
                    next = item.Parent.node.Right;
                }
                else
                {
                    if (item.Parent.Left == null)
                        item.Parent.EndPos = item.StartPos - 1;
                    else
                        item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                }
            }
        }
        Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        Console.WriteLine();
    }
    private static void Print(string s, int top, int left, int right = -1)
    {
        Console.SetCursorPosition(left, top);
        if (right < 0) right = left + s.Length;
        while (Console.CursorLeft < right) Console.Write(s);
    }
}