namespace Week11;

/***********************************************************
* CSC205 Assignment 11 
* Question 1
***********************************************************/

using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    /*
     * 1) your description here to describe the method below using a few sentences,
     *    if possible, insert some comments where in the program you think appropriate
     */
    static bool CheckParenthesesA(string str)
    {
        var stk = new Stack<char>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
            {
                stk.Push(str[i]);
            }
            else if (str[i] == ')' && !stk.IsEmpty())
            {
                stk.Pop();
            }
            if (stk.IsEmpty() && i < str.Length - 1)
            {
                return false;
            }
        }
        return stk.IsEmpty();
    } // end of CheckParenthesesA

    /*
     * 2) your description here to describe the method below using a few sentences, 
     *    if possible, insert some comments where in the program you think appropriate
     */
    static int CheckParenthesesB(string str)
    {
        var stk = new Stack<int>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
            {
                stk.Push(i);
            }
            if (str[i] == ')')
            {
                if (!stk.IsEmpty())
                {
                    stk.Pop();
                }
                else
                {
                    return i;
                }
            }
        }
        if (!stk.IsEmpty())
        {
            return (stk.Pop());
        }
        else
        {
            return -1;
        }
    } // end of CheckParenthesesB

    static void Main(string[] args)
    {
        // 3) your code below to thoroughtly test the two methods:
        //    CheckcheckParenthesesA and checkParenthesesB
    } // end of Main
}

// A simple Stack implementation for your convenience.
public class Stack<TYPE>
{
    TYPE[] values; //data stored in an array
    int top = -1, capacity = 1024;
    public Stack()
    {
        values = new TYPE[capacity];
        top = -1;
    }
    public bool IsEmpty()
    {
        return (top < 0);
    }
    public bool Push(TYPE data)
    {
        if (top == capacity - 1)
        {
            throw new Exception("Stack overflow!");
        }
        else
        {
            values[++top] = data;
            return true;
        }
    }
    public TYPE Pop()
    {
        if (top < 0)
        {
            throw new Exception("Can't pop an empty stack");
        }
        else
            return values[top--];
    }
    public TYPE Peek()
    {
        if (top < 0)
        {
            Console.WriteLine("Peek - no item in an empty stack");
            return default(TYPE);
        }
        else
            return values[top];
    }
    public void Clear()
    {
        top = -1;
    }
    public void Display()
    {
        if (top < 0)
        {
            Console.WriteLine("Empty stack");
            return;
        }
        else
        {
            Console.Write("Stack content: \ntop ->");
            for (int i = top; i >= 0; i--)
            {
                Console.Write(" " + values[i]);
            }
            Console.WriteLine();
        }
    }
}
