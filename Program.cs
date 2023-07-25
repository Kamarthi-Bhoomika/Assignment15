using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15_OuickSort
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
        static void Main(string[] args)
        {
            int[] array1 = { 3, 5, 6, 4, 2, 21, 76, 34, 12, 23, 89, 99, 74, 76, 64, 30, 45, 19, 43, 18 };
            Console.WriteLine("Array Before Sorting");
            Print(array1);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(array1);
            stopwatch.Stop();
            Console.WriteLine("After Quick Sort");
            Print(array1);
            Console.WriteLine($"Array Size {array1.Length}" +
                $" Time taken {stopwatch.Elapsed.TotalMilliseconds} milliseconds");

            Console.WriteLine("\n**********************************");
            int[] array2 = { 22, 44, 55, 33, 90, 67, 54, 34, 73, 82, 3, 5, 6, 4, 2, 21, 76, 34, 12, 23, 89, 99, 74, 76, 64, 30, 45, 19, 43, 18 };
            Console.WriteLine("Array Before Sorting");
            Print(array2);
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            QuickSort(array2);
            stopwatch2.Stop();
            Console.WriteLine("After Quick Sort");
            Print(array2);
            Console.WriteLine($"Array Size {array2.Length}" +
                $" Time taken {stopwatch2.Elapsed.TotalMilliseconds} milliseconds");

            Console.WriteLine("\n**********************************");
            int[] array3 = { 46, 58, 29, 30, 0, -8, -45, -20, 5, 68, -34, 87, 96, 55, -12, 45, 6, 14, 27, 12, 22, 44, 55, 33, 90, 67, 54, 34, 73, 82, 3, 5, 6, 4, 2, 21, 76, 34, 12, 23, 89, 99, 74, 76, 64, 30, 45, 19, 43, 18 };
            Console.WriteLine("Array Before Sorting");
            Print(array3);
            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            QuickSort(array3);
            stopwatch3.Stop();
            Console.WriteLine("After Quick Sort");
            Print(array3);
            Console.WriteLine($"Array Size {array3.Length}" +
                $" Time taken {stopwatch3.Elapsed.TotalMilliseconds} milliseconds");

            Console.WriteLine("\n**********************************");
            int[] arr1 = { 3, 5, 6, 4, 2, 21, 76, 34, 12, 23, 89, 99, 74, 76, 64, 30, 45, 19, 43, 18 };
            Console.WriteLine("Original array: " + string.Join(",", arr1));
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            MergeSort(arr1);
            stopwatch4.Stop();
            Console.WriteLine("Merge Sort Array: " + string.Join(",", arr1));
            Console.WriteLine($"Array Size {arr1.Length}" +
                $" Time taken {stopwatch4.Elapsed.TotalMilliseconds} milliseconds");

            Console.WriteLine("\n**********************************");
            int[] arr2 = { 22, 44, 55, 33, 90, 67, 54, 34, 73, 82, 3, 5, 6, 4, 2, 21, 76, 34, 12, 23, 89, 99, 74, 76, 64, 30, 45, 19, 43, 18 };
            Console.WriteLine("Original array: " + string.Join(",", arr2));
            Stopwatch stopwatch5 = new Stopwatch();
            stopwatch5.Start();
            MergeSort(arr2);
            stopwatch5.Stop();
            Console.WriteLine("Merge Sort Array: " + string.Join(",", arr2));
            Console.WriteLine($"Array Size {arr2.Length}" +
                $" Time taken {stopwatch5.Elapsed.TotalMilliseconds} milliseconds");

            Console.WriteLine("\n**********************************");
            int[] arr3 = { 46, 58, 29, 30, 0, -8, -45, -20, 5, 68, -34, 87, 96, 55, -12, 45, 6, 14, 27, 12, 22, 44, 55, 33, 90, 67, 54, 34, 73, 82, 3, 5, 6, 4, 2, 21, 76, 34, 12, 23, 89, 99, 74, 76, 64, 30, 45, 19, 43, 18 };
            Console.WriteLine("Original array: " + string.Join(",", arr3));
            Stopwatch stopwatch6 = new Stopwatch();
            stopwatch6.Start();
            MergeSort(arr3);
            stopwatch6.Stop();
            Console.WriteLine("Merge Sort Array: " + string.Join(",", arr3));
            Console.WriteLine($"Array Size {arr3.Length}" +
                $" Time taken {stopwatch6.Elapsed.TotalMilliseconds} milliseconds");

            Console.ReadKey();
        }
    }
}
