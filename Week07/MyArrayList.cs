/*
 * A simple implementation of ArrayList ADT 
 * Week 7 programming assignment 
 * #1: Implement all the empty methods that are marked with “throw new NotImplementedException();”. 
 * Last update: 3/30/2025
 */

namespace Week07
{
    internal class MyArrayListTest
    {
        static void Main(string[] args)
        {
            // create an instance of MyArrayList
            MyArrayList list = new MyArrayList();

            // check count and capacity
            Console.WriteLine($"An empty list is created, count={list.Count}, capacity={list.Capacity}");

            //add to these numbers to the list
            list.Add(3);
            Console.WriteLine($"After appending 3: Count={list.Count}, capacity={list.Capacity}");
            list.Add(1);
            Console.WriteLine($"After appending 1: Count={list.Count}, capacity={list.Capacity}");
            list.Add(2);
            Console.WriteLine($"After appending 2: Count={list.Count}, capacity={list.Capacity}");
            list.Add(5);
            Console.WriteLine($"After appending 5: Count={list.Count}, capacity={list.Capacity}");
            list.Add(0);
            Console.WriteLine($"After appending 0: Count={list.Count}, capacity={list.Capacity}");
            Console.Write("Now the list is: ");
            Console.WriteLine(list);
            Console.WriteLine("Element at index 3: " + list[3]);
            list.Sort(); // sort the list using built-in QuickSort algorithm
            Console.Write("After sorting: ");
            Console.WriteLine(list);
            list.Clear();
            Console.WriteLine($"After invoking Clear(), Count={list.Count}, capacity={list.Capacity}");
            
            Console.WriteLine("\nWeek 7 programming assignment #1:");
            Console.WriteLine("Create an array list instance out of an existing array: 7, 2, 6, 3, 2");
            int[] arr = { 7, 2, 6, 3, 2 };
            MyArrayList list2 = new MyArrayList(arr);
            Console.WriteLine(list2);
            Console.WriteLine($"Index of 2 is {list2.IndexOf(2)}");
            Console.WriteLine($"Index of 2 (second one) after index 3 is {list2.IndexOf(2, 3)}");
            list2.Reverse();
            Console.WriteLine($"After invoking Reverse method: {list2}");

            Console.WriteLine("\nWeek 7 programming assignment #2:");
            //create an instance
            MyArrayList<int> list3 = new MyArrayList<int>();
            //check count and capacity
            Console.WriteLine("Newly created list count: " + list3.Count);
            //add to this list
            Console.WriteLine("Add 3:");
            list3.Add(3);
            Console.WriteLine($"Count: {list3.Count}, Capacity: {list3.Capacity}");
            Console.WriteLine("Add 1:");
            list3.Add(1);
            Console.WriteLine($"Count: {list3.Count}, Capacity: {list3.Capacity}");
            Console.WriteLine("Add 2:");
            list3.Add(2);
            Console.WriteLine($"Count: {list3.Count}, Capacity: {list3.Capacity}");
            Console.WriteLine("Add 5:");
            list3.Add(5);
            Console.WriteLine($"Count: {list3.Count}, Capacity: {list3.Capacity}");
            Console.WriteLine("Add 0:");
            list3.Add(0);
            Console.WriteLine($"Count: {list3.Count}, Capacity: {list3.Capacity}");
            list3.DisplayList();
            //clear the list
            Console.WriteLine("List cleared!");
            list3.Clear();
            Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");
        }
    }

    internal class MyArrayList
    {
        private int[] _values; // ArrayList data are stored in an array called _values
        public int Count { get; private set; }
        public int Capacity
        {
            get { return _values.Length; }
        }

        // constructor 1: initializes a new instance of the ArrayList class that is empty and has default capacity of 4
        public MyArrayList(int Capacity = 4)
        {
            _values = new int[Capacity]; // allocate the array
            Count = 0; // initially, count is set to 0;
        }

        // constructor 2: initializes a new instance of the ArrayList class that contains elements copied from an existing array
        public MyArrayList(int[] a)
        {
            //throw new NotImplementedException();
            _values = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                _values[i] = a[i];
            }
            Count = a.Length;
        }

        // append a new element to the end of list
        public void Add(int newValue)
        {
            // check if array is full
            if (Count == Capacity)
            {
                Resize();
            }
            // put newValue into the array at index count
            _values[Count] = newValue;
            Count++;
        }

        private void Resize()
        {
            // create a new array of double capacity
            int[] tmp = new int[2 * Capacity];
            // copy over the old _values
            for (int pos = 0; pos < Capacity; pos++)
            {
                tmp[pos] = _values[pos];
            }
            // Reference _values array to the new tmp array
            _values = tmp;
        }

        public void AddLast(int newValue)
        {
            Add(newValue); // Add method adds a new value to the end
            // or try this: insert(newValue, Count)
        }

        public void AddFirst(int newValue)
        {
            Insert(newValue, 0);
        }

        // insert a new value at a given index
        public void Insert(int newValue, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count}");
            // check if the array is full, double its capacity if needed
            if (Count == Capacity)
                Resize();
            // shift everything from position i to Count-1, to the right by one position
            for (int i = Count; i > index; i--)
            {
                _values[i] = _values[i - 1];
            }
            // insert the new value
            _values[index] = newValue;
            Count++;
        }

        public void DeleteLast()
        {
            if (Count == 0) //you CAN'T delete anything from an empty list
                throw new IndexOutOfRangeException("You CAN'T delete last from an empty list");
            Count--; // just decrement the Count without removing it
        }

        public void DeleteFirst()
        {
            Delete(0);
        }

        // delete an element at a given index
        public void Delete(int index)
        {
            // validate index
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count - 1}");
            // shift everything (that is past index i) to the left one position
            for (int i = index; i < Count - 1; i++)
                _values[i] = _values[i + 1];
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

        // reverse the elements of list
        public void Reverse()
        {
            //throw new NotImplementedException();
            int temp;
            for (int i = 0; i < Count/2; i++)
            {
                temp = _values[i];
                _values[i] = _values[Count-1-i];
                _values[Count-1-i] = temp;
            }
        }

        // return the index of the first occurrence of a given value in this list.
        public int IndexOf(int value)
        {
            //throw new NotImplementedException();
            for (int i = 0; i < Count; i++)
            {
                if (value == _values[i]) return i;
            }
            return -1;
        }

        // return the index of the first occurrence of a given value in this list.
        // the list is searched forwards, starting at index startIndex
        public int IndexOf(int value, int startIndex)
        {
            //throw new NotImplementedException();
            for (int i = startIndex; i < Count; i++)
            {
                if (value == _values[i]) return i;
            }
            return -1;
        }

        public bool Contains(int value)
        {
            //throw new NotImplementedException();
            return IndexOf(value) >= 0;
        }

        // indexer allows indexing like t[2] to work if t is an instance of ArrayList
        public int this[int i]
        {
            get { return _values[i]; }
            set { _values[i] = value; }
        }

        public override string ToString()
        {
            string result = "";
            if (!IsEmpty())
            {
                for (int i = 0; i < Count; i++)
                {
                    result += _values[i] + " ";
                }
            }
            return result;
        }

        // sort the list using a built-in quick sort algorithm
        public void Sort()
        {
            QuickSortHelper(_values, 0, Count - 1);
        }

        private static void QuickSortHelper(int[] arr, int startIdx, int endIdx)
        {
            if (startIdx < endIdx) //if we have at least 2 elements in the "slice"
            {
                int q = Partition(arr, startIdx, endIdx); //partition the array
                QuickSortHelper(arr, startIdx, q - 1); //sort the first "half" before the pivot
                QuickSortHelper(arr, q + 1, endIdx); //sort the second "half" after the pivot
            }
        }

        private static int Partition(int[] arr, int startIdx, int endIdx)
        {
            int pivot = arr[endIdx];//last element = the pivot

            int holder = startIdx - 1; //will tell the position of the last <= pivot value
            for (int i = startIdx; i < endIdx; i++)
            {
                if (arr[i].CompareTo(pivot) <= 0)
                {
                    holder++;
                    int tmp = arr[i];
                    arr[i] = arr[holder];
                    arr[holder] = tmp;
                }
            }
            holder++;
            // swapping
            int tmp2 = arr[endIdx];
            arr[endIdx] = arr[holder];
            arr[holder] = tmp2;
            return holder;
        }
    }
}