using System;
using System.Linq;

namespace CounterProductiveSort
{
    public class Program
    {
        public static void CounterProductiveSort(int[] array)
        {
            // najdeme si minimum, maximum
            int max = array.Max();
            int min = array.Min();
            // vypočítáme si rozmezí
            int range = max - min + 1;
            
            // pole pro počítání výskytů
            int[] count = new int[range];
            // pole pro výsledek
            int[] output = new int[array.Length];

            // sečteme počet všech prvcků
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i] - min]++;
            }

            // odečteme 
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            // složíme výstup
            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[count[array[i] - min] - 1] = array[i];
                count[array[i] - min]--;
            }

            // nakopírujeme zpátky
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = output[i];
            }
        }
    }
}
