using System;
using System.Linq;
using System.Collections;

namespace DatoveStruktury
{
    class Program
    {
        static void Main(string[] args)
        {
            Test((ref int[] a) => Insert(ref a, 5, 3), "name");
            Test((ref int[] a) => Delete(ref a, 5), "delete");
            Test((ref int[] a) =>
            {
                (var odd, var even) = SplitOddEven(a);
                Console.Write("odd  ");
                WriteArray(odd);
                Console.Write("even ");
                WriteArray(even);
                a = ZippingJoin(odd, even);
            }, "split odd even -> zipping join");
        }

        delegate void TestDelegate(ref int[] array);

        static void Test(TestDelegate de, string testName = "")
        {
            testName += " ";
            Random random = new Random();
            {
                int[] array = Enumerable.Range(0, 30).Select(_ => random.Next()).ToArray();

                Console.Write(testName);
                WriteArray(array);
                de(ref array);
                Console.Write(testName);
                WriteArray(array);
            }
            Console.WriteLine();
        }

        static void WriteArray<T>(T[] arr)
        {
            Console.WriteLine(String.Join(", ", arr));
        }

        /// <summary>
        /// ouchie - The array that gets modified.<br/>
        /// index - Indicates where to put the new element.<br/>
        /// value - Tells the new value.
        /// </summary>
        /// <param name="ouchie"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void Insert<T>(ref T[] ouchie, int index, T value)
        {
            T[] newguy = new T[ouchie.Length + 1];
            Array.Copy(ouchie, newguy, index);
            newguy[index] = value;
            Array.Copy(ouchie, index, newguy, index + 1, ouchie.Length - index);
            ouchie = newguy;
        }

        /// <summary>
        /// ouchie - The array that gets modified.<br/>
        /// index - Indicates where in the array.
        /// </summary>
        /// <param name="ouchie"></param>
        /// <param name="index"></param>
        public static void Delete<T>(ref T[] ouchie, int index)
        {
            T[] newguy = new T[ouchie.Length - 1];
            Array.Copy(ouchie, 0, newguy, 0, index);
            Array.Copy(ouchie, index + 1, newguy, index, ouchie.Length - index - 1);
            ouchie = newguy;
        }

        /// <summary>
        /// ouchie - First array (odd).<br/>
        /// second - Second array (even).
        /// </summary>
        /// <param name="ouchie"></param>
        /// <param name="second"></param>
        public static T[] ZippingJoin<T>(T[] ouchie, T[] second)
        {
            T[] arr = new T[ouchie.Length + second.Length];

            for (int i = 0; i < arr.Length; i += 2)
            {
                if (ouchie.Length > i / 2)
                    arr[i + 0] = ouchie[i / 2];
                if (second.Length > i / 2)
                    arr[i + 1] = second[i / 2];
            }

            return arr;
        }

        /// <summary>
        /// ouchie - First array.
        /// </summary>
        /// <param name="ouchie"></param>
        /// <param name="second"></param>
        public static (T[], T[]) SplitOddEven<T>(T[] ouchie)
        {
            T[] odd = new T[ouchie.Length / 2 + ouchie.Length % 2];
            T[] even = new T[ouchie.Length / 2];

            for (int i = 0; i < ouchie.Length; i++)
            {
                if (i % 2 == 0)
                    odd[i / 2] = ouchie[i];
                else
                    even[i / 2] = ouchie[i];
            }

            return (odd, even);
        }
    }
}
