/*
 * A simple implementation of Generic ArrayList ADT 
 * Week 7 programming assignment 
 * #2: Change the non-generic ArrayList implementation above to a generic version, 
 * test it thoroughly in the MyArrayListTest class.
 * Last update: 3/30/2025
 */

namespace Week07
{
    class MyArrayList<T>
    {
        T[] values; //data stored in an array
        public int Count { get; private set; }
        public int Capacity
        {
            get { return values.Length; }
            set { Capacity = value; }
        }

        public MyArrayList(int Capacity = 4) //constructor
        {   //allocate an array of size = Capacity or 4 by default 
            values = new T[Capacity];
            Count = 0; //initially count is set to 0;
        }

        public void Add(T newValue)
        {
            //check if array is full
            if (Count == Capacity)
            {
                Resize();
            }
            //put newValue into the array at position count
            values[Count] = newValue;
            Count++;
        }

        public void Resize()
        {
            //create a new array of double capacity
            T[] tmp = new T[2 * Capacity];
            //copy over the old value
            for (int pos = 0; pos < Capacity; pos++)
            {
                tmp[pos] = values[pos];
            }
            //reference values array to the new tmp array
            values = tmp;
            Console.WriteLine("Resize array to " + Capacity);
        }

        public void AddLast(T newValue)
        {
            Add(newValue);
            //Insert(newValue, Count)
        }

        public void AddFirst(T newValue)
        {
            Insert(newValue, 0);
        }

        public void Insert(T newValue, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count}");
            //check if the array is full, double its capacity if needed
            if (Count == Capacity)
                Resize();
            //shift everything from position i thru Count-1 to the right by one position
            for (int i = Count; i > index; i--)
            {
                values[i] = values[i - 1];
            }
            //insert the new value
            values[index] = newValue;
            Count++;
        }

        public void DeleteLast()
        {
            if (Count == 0) //you CAN't delete last from an empty list
                throw new IndexOutOfRangeException("You CAN't delete last from an empty list");
            Count--;
        }
        public void DeleteFirst()
        {
            Delete(0);
        }
        public void Delete(int index)
        {
            //validate index
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count - 1}");
            //shift everything (that is past index i) to the left one position
            for (int i = index; i < Count - 1; i++)
                values[i] = values[i + 1];
            Count--;
        }
        public void Clear()
        {
            Count = 0; // too simple?
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void DisplayList()
        {
            if (IsEmpty())
                Console.WriteLine("Empty list!");
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Write((values[i]) + " ");
                }
                Console.WriteLine();
            }
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public T this[int i] //indexer
        {
            get { return values[i]; }
            set { values[i] = value; }
        }
    }
}
