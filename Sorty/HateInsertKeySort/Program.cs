using System;

namespace HateInsertKeySort
{
    public class Program
    {
        public static void HateInsertKeySort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                // když najdeme menší prvek, tak ho pošleme dozádu
                if (array[i - 1].CompareTo(array[i]) == 1)
                {
                    SendBack(array, i);
                }
            }
        }

        static void SendBack<T>(T[] array, int index) where T : IComparable<T>
        {
            int lookback = index - 1;
            while (lookback >= 0)
            {
                // koncová podmínka
                if (array[lookback].CompareTo(array[index]) != 1)
                {
                    break;
                }
                
                // cestou zpátky vymněňujeme
                T tmp = array[index];
                array[index] = array[lookback];
                array[lookback] = tmp;

                lookback--;
                index--;
            }
        }
    }
}
