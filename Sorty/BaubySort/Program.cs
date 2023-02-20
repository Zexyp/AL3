using System;

namespace BaubySort
{
    public class Program
    {
        public static void BaubySort<T>(T[] array) where T : IComparable<T>
        {
            for (int thei = 0; thei < array.Length; thei++)
            {
                // procházíme pole na druhou aby měl každý prvek šanci probublat
                for (int j = 1; j < array.Length - thei; j++)
                {
                    // máme posouvat číslo vpřed?
                    if (array[j].CompareTo(array[j - 1]) == -1)
                    {
                        T tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                    }
                }
            }
        }
    }
}
