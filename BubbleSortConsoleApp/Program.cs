using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BubbleSortConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var executionTimeWatcher = Stopwatch.StartNew();
            // var start = DateTime.Now;
            int count = 100_000_000;
            for (int i = 0; i < count; i++)
            {
                var arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                BubbleSort(arr.AsSpan());
            }

            ///Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
            Console.WriteLine((executionTimeWatcher.Elapsed.TotalMilliseconds));

            Console.ReadLine();
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static void BubbleSort(Span<int> arr)
        {
            var len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
