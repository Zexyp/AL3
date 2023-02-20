using System;

namespace QuickieSort
{
    public class Program
    {
        public static void QuickieSort<T>(T[] array) where T : IComparable<T>
        {
            RecursiveKekel(array, 0, array.Length - 1);
        }

        static void RecursiveKekel<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
                return;

            int pivot = start;

            // pivot hodíme na konec
            {
                T tmp = array[pivot];
                array[pivot] = array[end];
                array[end] = tmp;
            }

            int index = start;

            for (int i = start; i <= end - 1; i++)
            {
                // když je prvek menší než pivot prohodíme
                if (array[i].CompareTo(array[end]) == -1)
                {
                    T tmp = array[i];
                    array[i] = array[index];
                    array[index] = tmp;

                    index++;
                }
            }

            // prohodíme pivot s indexem
            {
                T tmp = array[end];
                array[end] = array[index];
                array[index] = tmp;
            }

            // třídíme *poloviny*
            RecursiveKekel(array, start, index - 1);
            RecursiveKekel(array, index + 1, end);
        }
    }
}
