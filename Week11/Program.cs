/***********************************************************
* CSC205 Assignment 11 
* Question 1
***********************************************************/

namespace Week11;

using System;
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

        var d = new MyDictionary<string, decimal>();
        d.Add("Ford Focus", 26500m);
        d.Add("Honda Pilot", 37000m);
        d.Add("Ford Focus", 28500m);

        foreach (var k in d)
        {
            Console.WriteLine($"{k}:{d.Get((string)k)}");
        }
    }
}