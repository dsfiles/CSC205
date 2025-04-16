/***********************************************************
* CSC205 Assignment 11 
* Question 2
***********************************************************/

namespace Week11;

using System;
using System.Collections;

public class MyDictionary<K, V>: IEnumerable
{
    private K[] keys;
    private V[] values;
    private int size;
    private int capacity;

    public MyDictionary(int initialCapacity = 8)
    {
        capacity = initialCapacity;
        size = 0;
        keys = new K[capacity];
        values = new V[capacity];
    }

    // Add a key-value pair to the dictionary
    public void Add(K key, V value)
    {
        // Check if the dictionary is full and resize if necessary
        // If the key exists, update the corresponding value
        // Add the new key and its value to the arrays
        throw new NotImplementedException();
    }

    // Get the value associated with a key
    public V Get(K key)
    {
        for (int i = 0; i < size; i++)
        {
            if (keys[i].Equals(key))
            {
                return values[i];
            }
        }
        throw new KeyNotFoundException("The key was not found.");
    }

    // Check if the dictionary contains a particular key
    public bool ContainsKey(K key)
    {
        throw new NotImplementedException();
    }

    // Resize the arrays when the dictionary is full
    private void Resize()
    {
        throw new NotImplementedException();
    }

    // Get the current number of items in the dictionary
    public int Count => size;

    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < size; index++)
        {
            yield return keys[index];
        }
    }
}
