using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Linq;

namespace HaldaSort
{
    public static class Program
    {
        public  static void HaldaSort<T>(T[] array) where T : IComparable<T>
        {
            int index = array.Length - 1;
            // procházíme pozadu
            while (index > 0)
            {
                // složíme binary heap
                Heapify(array, index + 1);

                // pošleme maximum na konec
                T tmp = array[0];
                array[0] = array[index];
                array[index] = tmp;
                index--;
            }
        }

        static void Heapify<T>(T[] array, int count) where T : IComparable<T>
        {
            // necháme všechny uzly probublat k maximu
            for (int i = 0; i < count; i++)
                Bubbly(array, i);
        }

        static void Bubbly<T>(T[] array, int index) where T : IComparable<T>
        {
            while (index != 0)
            {
                int parent = IxParent(index);

                // prohodíme s rodičem pokud potřeba
                if (array[parent].CompareTo(array[index]) == -1)
                {
                    T tmp = array[parent];
                    array[parent] = array[index];
                    array[index] = tmp;
                    index = parent;
                }
                else
                    return;
            }
        }

        // pomocné vzorce
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int IxParent(int i) => (i - 1) / 2;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int IxLeftChild(int i) => 2 * i + 1;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int IxRightChild(int i) => 2 * i + 2;
    }
}
