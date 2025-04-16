/*
 * A simple BST implementation in C#
 * 12/2024
 */

namespace BinarySearchTreeV1;

public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node Parent { get; set; }
    public Node(int data)
    {
        Key = data;
        Parent = Left = Right = null;
    }
}

class BinarySearchTree
{
    public Node _root;
    public Node Count { get; set; }
    public BinarySearchTree()
    {
        _root = null;
    }

    /* A utility function to insert a new Node with given key in BST */
    public void Insert(int data)
    {
        // If the tree is empty, the new node is root node
        if (_root == null)
        {
            _root = new Node(data);
            return;
        }
        // Otherwise, move down the tree
        Node ptr = _root;
        if (ptr.Key == data)
        {
            Console.WriteLine("can't insert a duplicated value");
            return;
        }
        while (data < ptr.Key && ptr.Left != null)
        {
            ptr = ptr.Left;
        }
        while (data > ptr.Key && ptr.Right != null)
        {
            ptr = ptr.Right;
        }
        if (data < ptr.Key) // new Node is left child
        {
            ptr.Left = new Node(data);
            ptr.Left.Parent = ptr;
        }
        else
        {
            ptr.Right = new Node(data);
            ptr.Right.Parent = ptr;
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
        return ptr.Left == null & ptr.Right == null;
    }

    public void DeleteNode(Node ptr, int data)
    {
        if (ptr == null)
        {
            //throw new Exception("Failed!");
            Console.WriteLine("No node is deleted!");
            return;
        }
        if (data < ptr.Key)
            DeleteNode(ptr.Left, data);
        else if (data > ptr.Key)
            DeleteNode(ptr.Right, data);
        else // Found the node to be delete
        {
            //If the node is leaf
            if (IsLeaf(ptr))
            {
                if (ptr == ptr.Parent.Left)
                    ptr.Parent.Left = null;
                else
                    ptr.Parent.Right = null;
                //ptr = null; // Make the node NULL
                return;
            }
            // Node with a left child only
            else if (ptr.Right == null)
            {
                ptr = ptr.Left;
                return;
            }
            // Node with a right child only
            else if (ptr.Left == null)
            {
                ptr = ptr.Right;
                return;
            }
            else // Node with both children
            {
                int succ = Successor(ptr);
                ptr.Key = succ;
                // Delete the inorder successor
                DeleteNode(ptr.Right, succ);
            }
        }
    }

    private void DisplayTree(Node ptr) // In-order
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
        DisplayTree(_root);
    }

}


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
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(2);
        bst.Insert(4);
        bst.Insert(7);
        bst.Insert(6);
        bst.Insert(8);
        // Inorder traversal of the BST
        bst.Inorder();
        Console.WriteLine();
        Console.WriteLine("Root's successor");
        Console.WriteLine(bst.Successor(bst._root));
        Console.WriteLine("preccessor");
        Console.WriteLine(bst.Predecessor(bst._root));

        Console.WriteLine("\nDelete node 3:");
        bst.DeleteNode(bst._root, 3);
        bst.DisplayTree();  
        Console.WriteLine("\nInsert node 3:");
        bst.Insert(3);
        bst.DisplayTree();
    }
}
