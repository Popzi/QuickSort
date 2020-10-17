#define PRINTARRAYS //Define to show array contents before and after sorting
#define COMPARE // Define to compare Insertionsort vs QuickSort, undefine to let the program choose InsertionSort <= 10 in array else QuickSort.
////////////////////////
////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class QuickSort
    {
        #region Quick_Sort
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            int i;

              if(right - left < 10)
              {
                  Insertion_Sort(arr, arr.Length);
              } 
              else
              {   
            if (left < right)
            {
                i = Partition(arr, left, right);
                Quick_Sort(arr, left, i - 1);
                Quick_Sort(arr, i + 1, right);
            }
             }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int pIndex = left;

            for(int i = left; i < right; i++)
            {
                if(arr[i] <= pivot)
                {
                    Swap(ref arr[i], ref arr[pIndex]);
                    pIndex++;
                }
            }
            Swap(ref arr[pIndex], ref arr[right]);
            return pIndex;
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
        #endregion

        #region InsertSort
        private static void Insertion_Sort(int[] arr,int n)
        {
            int i, j, val, flag;
            for (i = 1; i < n; i++)
            {
                val = arr[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                    }
                    else flag = 1;
                }
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Random _random = new Random();
            //////
            /// Total of elements in array
            int max = 20; // 100000000 ~ ca 23,5 sekunder
            //////
            /// Loggad data:
            /// 00.0003099 insert n=10
            /// 00.0003020 quick n=11
            /// 00.0003136 quick n=11
            /// 00.0003957 insert n=10
            /// 00.0002956 quicksort utan insert n=10
            /// 00.0003000 quicksort utan insert n=10
            /// 00.0003000 insertion sort n=10
            /// 00.0003343 insertion n=10
            /// 00.0003107 quicksort med insert n=11
            /// 00.0003046 quicksort med insert n=11
#if (COMPARE)
            #region COMPARE
            #region QuickSortPart
            /*int[] arr = Enumerable.Range(0, max)
                        .Select(r => _random.Next(100))
                        .ToArray(); */
            int[] arr = { 2, 2, 2, 2, 1, 2, 2, 1, 2, 1, 1, 1, 2, 1, 2, 1, 2, 2, 2, 1, 0, 0, 1, 1, 5 };
            int[] iarr = new int[arr.Length];
            arr.CopyTo(iarr, 0);

            Console.WriteLine("Quick Sort:");
            Console.WriteLine("Original array : ");
#if (PRINTARRAYS)
            Console.WriteLine(string.Join(",", arr));
#else
            Console.WriteLine($"Sorted {arr.Length} elements");
#endif
            Console.WriteLine();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Quick_Sort(arr, 0, arr.Length - 1);
            watch.Stop();
            var elapsedMs = watch.Elapsed;
            Console.WriteLine();
            Console.WriteLine("Sorted array : ");
#if (PRINTARRAYS)
            Console.WriteLine(string.Join(",", arr));
#else
            Console.WriteLine($"Sorted {arr.Length} elements");
#endif
            Console.WriteLine("\nTime taken: " + elapsedMs);
            #endregion
            #region InsertSortPart
            Console.WriteLine();
            Console.WriteLine("Insertion sort:");           
#if (PRINTARRAYS)
            Console.WriteLine("Original array : ");
            Console.WriteLine(string.Join(",", iarr));
#else
            Console.WriteLine($"Array contains {iarr.Length} elements");
#endif
            Console.WriteLine();
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            Insertion_Sort(iarr, iarr.Length);
            watch2.Stop();
            var elapsedMs2 = watch2.Elapsed;
            Console.WriteLine();
#if (PRINTARRAYS)
            Console.WriteLine("Sorted array : ");
            Console.WriteLine(string.Join(",", iarr));
#else
            Console.WriteLine($"Sorted {iarr.Length} elements");
#endif
            Console.WriteLine("\nTime taken: " + elapsedMs2);
            Console.ReadLine();
            #endregion
            #endregion
#else
            #region QuickorInsertionBasedOnArrayLength
              int[] arr = Enumerable.Range(0, max)
            .Select(r => _random.Next(max))
            .ToArray(); 
            //   int[] arr = { 2, 2, 2, 2, 1, 2, 2, 1, 2, 1, 1, 1, 2, 1, 2, 1, 2, 2, 2, 1 };
            //   int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
#if (PRINTARRAYS)
            Console.WriteLine("Original array : ");
            Console.WriteLine(string.Join(",", arr));
#else
            Console.WriteLine($"Array Contains {arr.Length} elements");
#endif
            Console.WriteLine();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Quick_Sort(arr, 0, arr.Length - 1);
            watch.Stop();
            var elapsedMs = watch.Elapsed;
            Console.WriteLine();
#if (PRINTARRAYS)
            Console.WriteLine("Sorted array : ");
            Console.WriteLine(string.Join(",", arr));
#else
            Console.WriteLine($"Sorted {arr.Length} elements");
#endif
            Console.WriteLine("\nTime taken: " + elapsedMs);
            Console.ReadLine();
            #endregion
#endif

        }
    }
}
