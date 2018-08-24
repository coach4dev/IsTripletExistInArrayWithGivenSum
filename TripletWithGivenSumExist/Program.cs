using System;
using System.Collections.Generic;
using System.Linq;

namespace TripletWithGivenSumExist
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 9, 7, 6, 3, 5, 2, 8 };
            int sum = 10;
            
            var isTripletExist = IsTripletExistWithSum(arr, sum);

            Console.WriteLine(isTripletExist);

             isTripletExist = IsTripletExistWithSumWithSorting(arr, sum);

            Console.WriteLine(isTripletExist);

             isTripletExist = IsTripletExistWithSumWithHashSet(arr, sum);

            Console.WriteLine(isTripletExist);

            Console.ReadLine();
        }

        //naive solution with O(n^3)
        private static bool IsTripletExistWithSum(int[] arr, int sum)
        {
            if (arr == null || arr.Length < 3)
                return false;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == sum)
                            return true;
                    }
                }
            }
            return false;
        }

        //Solution with O(n^2) with sorting
        private static bool IsTripletExistWithSumWithSorting(int[] arr, int sum)
        {
            if (arr == null || arr.Length < 3)
                return false;

            QuickSort(arr, 0, arr.Length - 1);
            int left, right;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                left = i + 1;
                right = arr.Length - 1;
                while (left < right)
                {
                    if (arr[i] + arr[left] + arr[right] == sum)
                        return true;
                    else
                    {
                        if (arr[i] + arr[left] + arr[right] < sum)
                            left++;
                        else
                            right--;
                    }
                }
            }
            return false;
        }

        //Solution with HashSet O(n^2)
        private static bool IsTripletExistWithSumWithHashSet(int[] arr, int sum)
        {
            if (arr == null || arr.Length < 3)
                return false;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                HashSet<int> set = new HashSet<int>();
                int pairSumExpected = sum - arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (set.Contains(pairSumExpected - arr[j]))
                        return true;
                    set.Add(arr[j]);
                }
            }
            return false;
        }



        #region Helper methods

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int p = Partition(arr, low, high);
                QuickSort(arr, low, p - 1);
                QuickSort(arr, p + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, high);
            return i + 1;
        }

        static void swap(int[] ar, int a, int b)
        {
            int temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
        }

        #endregion
    }
}
