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
        int size = 10000; // Try array sizes of 10, 100, 1k, 10k, 100k, or even higher
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        int[] arr3 = new int[size];
        int[] arr4 = new int[size];
        int[] arr5 = new int[size];
        int[] arr6 = new int[size];

        // Create arrays of random numbers
        for (int i = 0; i < size; i++)
            arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = rand.Next();

        // Create sorted arrays in ascending order
        //for (int i = 0; i < size; i++)
        //    arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = i;

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

        /* uncomment each one after you add a sorting algorithm
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
        */
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
    
    /* fill out the missing code below:
    static void SelectionSort(int[] arr)
    {
        // your code here
    } //end of SelectionSort
    
    static void InsertionSort(int[] arr)
    {
        // your code here
    } //end of InsertionSort

    static void MergeSort(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }
    // Recursively sort the two halves and merge them into one sorted list
    static void MergeSort(int[] arr, int left, int right)
    {
        // your code here
    }
    // The following method merges two sorted portions of array into one sorted portion.
    // The start index and end index are left & mid for the left portion, and mid+1 & right
    // for the right portion of the original array.
    static void Merge(int[] arr, int left, int mid, int right)
    {
        // your code here
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
        // your code here
    }
    */
}