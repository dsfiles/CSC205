namespace Week11;

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
