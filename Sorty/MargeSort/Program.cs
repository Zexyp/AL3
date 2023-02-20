using System;

namespace MargeSort
{
    public class Program
    {
        public static void MargeSort<T>(T[] array) where T : IComparable<T>
        {
            Recursive(array, 0, array.Length - 1);
        }

        static void Recursive<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            // base case rekurze
            if (start >= end)
                return;

            int midbeast = (start + end) / 2;

            // rekurzivní část
            Recursive(array, start, midbeast);
            Recursive(array, midbeast + 1, end);

            // složení
            Merge(array, start, midbeast, end);
        }

        static void Merge<T>(T[] array, int start, int mid, int end) where T : IComparable<T>
        {
            // do polí si hodíme to, co budeme třídit
            T[] left = new T[mid - start + 1];
            T[] right = new T[end - mid];
            for (int i = 0; i < left.Length; i++)
                left[i] = array[start + i];
            for (int i = 0; i < right.Length; i++)
                right[i] = array[mid + 1 + i];

            // skládání zpět
            int ai = start;
            int ri = 0, li = 0;
            while (li < left.Length && ri < right.Length)
            {
                // co hodíme první?
                if (left[li].CompareTo(right[ri]) != 1)
                {
                    array[ai] = left[li];

                    // posun v levém poli
                    li++;
                }
                else
                {
                    array[ai] = right[ri];

                    // posun v pravém poli
                    ri++;
                }
                // posun v destinaci
                ai++;
            }

            // dohození zbytku
            while (li < left.Length)
            {
                array[ai] = left[li];

                // posun v levém poli
                li++;
                // posun v destinaci
                ai++;
            }
            while (ri < right.Length)
            {
                array[ai] = right[ri];

                // posun v pravém poli
                ri++;
                // posun v destinaci
                ai++;
            }
        }
    }
}
