/* CSC205 Week6 Assignment
* Write your own collection of sorting programs to implement these algorithms: 
*   Bubble sort, Insertion Sort, Selection Sort, Merge Sort, and Quick Sort. 
* Do you get the same relative timings as shown in the table? Figure 7.20 (Page 260)? 
* If not, why do you think this happened? How do your results compare with those of 
* your classmates? What does this say about the difficulty of doing empirical timing studies?
*/

using System;
using System.Diagnostics;
class SortingAlgorithms
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        Stopwatch stopwatch = new Stopwatch(); // Create a stopwatch object to track time elapse
        int size = 50_000; // Try array sizes of 10, 100, 1k, 10k, 100k, or even higher
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        int[] arr3 = new int[size];
        int[] arr4 = new int[size];
        int[] arr5 = new int[size];
        int[] arr6 = new int[size];

        // Create arrays of random numbers
        //for (int i = 0; i < size; i++)
        //    arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = rand.Next();

        // Create sorted arrays in ascending order
        for (int i = 0; i < size; i++)
            arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = i;

        // Create sorted arrays in descending order
        //for (int i = 0; i < size; i++)
        //    arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = size-1-i;
        
        Console.WriteLine($"Time (in milliseconds) to sort {size} numbers ...");
        stopwatch.Start();
        BubbleSort(arr1);
        stopwatch.Stop();
        Console.WriteLine($"Regular bubble sort: {stopwatch.Elapsed.TotalMilliseconds:0.0} ms");

        stopwatch.Restart();
        BubbleSortOptimized(arr2);
        stopwatch.Stop();
        Console.WriteLine($"Optimized bubble sort: {stopwatch.Elapsed.TotalMilliseconds:0.0} ms");
        
        // uncomment each one after you add a sorting algorithm
        stopwatch.Restart();
        SelectionSort(arr3);
        stopwatch.Stop();
        Console.WriteLine($"Selection sort: {stopwatch.Elapsed.TotalMilliseconds:0.0} ms");

        stopwatch.Restart();
        InsertionSort(arr4);
        stopwatch.Stop();
        Console.WriteLine($"Insertion sort: {stopwatch.Elapsed.TotalMilliseconds:0.0} ms");
        
        stopwatch.Restart();
        MergeSort(arr5);
        stopwatch.Stop();
        Console.WriteLine($"Merge sort: {stopwatch.Elapsed.TotalMilliseconds:0.0} ms");

        stopwatch.Restart();
        QuickSort(arr6);
        stopwatch.Stop();
        Console.WriteLine($"Quick sort: {stopwatch.Elapsed.TotalMilliseconds:0.0} ms");
    }

    static void BubbleSort(int[] arr)
    {
        int tmp;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                { // swap two adjacent elements if they are not in the intended order
                    tmp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = tmp;
                }
            }
        }
    }
    
    static void BubbleSortOptimized(int[] arr)
    {
        int tmp;
        bool flag = false;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                { // swap two adjacent elements if they are not in the intended order
                    tmp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = tmp;
                    flag = true;
                }
            }
            if (!flag)
            {
                return; // the array is already sorted
            }
        }
    }

    // Example Insertion, Selection, Merge, and Quick sorting algorithms below:

    static void SelectionSort(int[] arr)
    {
        int minIndex, tmp;
        for (int i = 0; i < arr.Length; i++)
        {
            minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            tmp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = tmp;
        }
    } //end of SelectionSort

    static void InsertionSort(int[] arr)
    {
        int curr, i, j;
        for (i = 1; i < arr.Length; i++)
        {
            curr = arr[i];
            for (j = i - 1; j >= 0 && arr[j] > curr; j--)
            {
                arr[j + 1] = arr[j];
            }
            arr[j + 1] = curr;
        }
    } //end of InsertionSort

    static void MergeSort(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }
    // Recursively sort the two halves and merge them into one sorted list
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }
    // The following method merges two sorted portions of array into one sorted portion.
    // The start index and end index are left & mid for the left portion, and mid+1 & right
    // for the right portion of the original array.
    static void Merge(int[] arr, int left, int mid, int right)
    {
        // Create a temporary array to store the sorted elements
        int[] m = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;
        // If both portions of array has elements, pick the smaller one
        while (i <= mid && j <= right)
        {
            if (arr[i] < arr[j])
                m[k++] = arr[i++];
            else
                m[k++] = arr[j++];
        }
        // Copy the remainder of the list
        while (i <= mid)
            m[k++] = arr[i++];
        // Copy the remainder of the list
        while (j <= right)
            m[k++] = arr[j++];
        // Copy sorted data from the temporary array back to the original array
        for (int index = 0; index < m.Length; index++)
        {
            arr[left + index] = m[index];
        }
    }

    static void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }
    static void QuickSort(int[] arr, int left, int right)
    {
        // return right way if there is only one element, i.e., left == right,
        // or there is none, i.e., left > right, 
        if (left < right)
        {
            int p = Partition(arr, left, right); // p is the index of pivot
            QuickSort(arr, left, p - 1);
            QuickSort(arr, p + 1, right);
        }
    }
    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right], tmp;
        int l = left;
        int r = right - 1;
        while (l < r)
        {
            while (arr[l] <= pivot && l < r) // also shift the l pointer when arr[l]==pivot
            {
                l++;
            }
            while (arr[r] > pivot && l < r)
            {
                r--;
            }
            if (l < r)
            {
                tmp = arr[l]; arr[l] = arr[r]; arr[r] = tmp;
            }
        }
        // With l and r overlapping, swap the current element with the pivot only if it is greater than the pivot
        if (arr[l] > arr[right])
        {
            tmp = arr[l]; arr[l] = arr[right]; arr[right] = tmp;
            return l;
        } else
        {
            return right; // pivot stays where it is
        }
    }
}