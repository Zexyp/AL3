using System;

namespace SelektioSort
{
    public class Program
    {
        public static void SelektioSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = array.Length - 1; i >= 1; i--)
            {
                // najdeme maximum
                int maxi = 0;
                for (int ii = 1; ii <= i; ii++)
                {
                    if (array[maxi].CompareTo(array[ii]) == -1)
                    {
                        maxi = ii;
                    }
                }

                // pošleme na konec
                T tmp = array[i];
                array[i] = array[maxi];
                array[maxi] = tmp;
            }
        }
    }
}
