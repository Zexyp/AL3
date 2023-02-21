using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace TestFramework
{
    class Program
    {
        const int LENGTH = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine($"Testing with length {LENGTH}");

            Action<int[]>[] acts = {
                SelektioSort.Program.SelektioSort,
                BaubySort.Program.BaubySort,
                HateInsertKeySort.Program.HateInsertKeySort,
                HaldaSort.Program.HaldaSort,
                MargeSort.Program.MargeSort,
                QuickieSort.Program.QuickieSort,
            };

            for (int i = 0; i < acts.Length; i++)
            {
                Test(acts[i]);
                
                Console.WriteLine();
            }

            Console.WriteLine("Now the unusable sort:");

            {
                int[] array = new int[LENGTH];

                Random random = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(0, 100);
                }

                CounterProductiveSort.Program.CounterProductiveSort(array);

                Console.WriteLine(IsSorted(array) ? "ok" : "failed");
            }
        }

        static void Test(Action<int[]> act)
        {
            // random pole
            int[] array = new int[LENGTH];

            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }

            

            Stopwatch sw = Stopwatch.StartNew();

            long initialmem = GC.GetTotalMemory(true);

            act.Invoke(array);

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
            
            if (IsSorted(array))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"OK ({act.Method.Name})");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Failed\nSomebody was dumb while coding '{act.Method.Name}'");
                Console.ResetColor();
                Debug.Assert(false);
            }
        }

        static bool IsSorted<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) == 1)
                {
                    Console.WriteLine($"Hmmm... {i} seems kinda sussy");
                    return false;
                }
            }

            return true;
        }
    }
}
