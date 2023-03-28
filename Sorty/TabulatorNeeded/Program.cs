using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Threading;

using Pastel;

namespace TabulatorNeeded
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SIZE_X = 5;
            const int SIZE_Y = 5;

            int[,] array = new int[SIZE_X, SIZE_Y];

            Random random = new Random();
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = random.Next(int.MinValue, int.MaxValue);
                }
            }

            SelektioSort(array);

            int maxlen = Math.Max(
                array[0, 0]
                    .ToString().Length,
                array[array.GetLength(0) - 1, array.GetLength(1) - 1]
                    .ToString().Length
                ) + 1;

            int time = 0;
            while (true)
            {
                Vector3 color = new Vector3(time * 0.02f, 1, 1);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine('┌' + String.Join('┬', Enumerable.Range(0, array.GetLength(0)).Select(_ => new string('─', maxlen)).ToArray()) + '┐');
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    Console.Write('│');
                    for (int x = 0; x < array.GetLength(0); x++)
                    {
                        foreach (var ch in array[y, y].ToString().PadLeft(maxlen))
                        {
                            color.X += 0.02f;
                            Console.Write(ch.ToString().Pastel(ColorUtils.HSVToRGB(color).ToColor()));
                        }
                        Console.Write('│');
                    }
                    Console.WriteLine();
                    if (y < array.GetLength(1) - 1)
                        Console.WriteLine('├' + String.Join('┼', Enumerable.Range(0, array.GetLength(0)).Select(_ => new string('─', maxlen)).ToArray()) + '┤');
                }
                Console.WriteLine('└' + String.Join('┴', Enumerable.Range(0, array.GetLength(0)).Select(_ => new string('─', maxlen)).ToArray()) + '┘');
                Thread.Sleep(100);
                time++;
            }
        }

        static unsafe void SelektioSort(int[,] funnyDarray)
        {
            if (funnyDarray.Length <= 0)
                return;

            int* array = null;
            fixed (int* p = &funnyDarray[0, 0])
                array = p;

            for (int i = funnyDarray.Length - 1; i >= 1; i--)
            {
                // najdeme maximum
                int maxi = 0;
                for (int ii = 1; ii <= i; ii++)
                {
                    if (array[maxi] < array[ii])
                    {
                        maxi = ii;
                    }
                }

                // pošleme na konec
                int tmp = array[i];
                array[i] = array[maxi];
                array[maxi] = tmp;
            }
        }
    }

    static class ColorUtils
    {
        public static Color ToColor(this Vector3 color)
        {
            return Color.FromArgb((int)Math.Clamp(color.X * 255, 0, 255), (int)Math.Clamp(color.Y * 255, 0, 255), (int)Math.Clamp(color.Z * 255, 0, 255));
        }

        public static Vector3 HSVToRGB(Vector3 hsvColor)
        {
            //while (hsvColor.X < 0) { hsvColor.X += 360; };
            //while (hsvColor.X >= 360) { hsvColor.X -= 360; };
            hsvColor.X = (hsvColor.X % 1.0f);
            if (hsvColor.X < 0)
                hsvColor.X += 1;
            hsvColor.X *= 6;
            Vector3 rgbColor = new Vector3();
            if (hsvColor.Z <= 0)
            {
                rgbColor.X = rgbColor.Y = rgbColor.Z = 0;
            }
            else if (hsvColor.Y <= 0)
            {
                rgbColor.X = rgbColor.Y = rgbColor.Z = hsvColor.Z;
            }
            else
            {
                float hf = hsvColor.X;
                int i = (int)Math.Floor(hf);
                float f = hf - i;
                float pv = hsvColor.Z * (1 - hsvColor.Y);
                float qv = hsvColor.Z * (1 - hsvColor.Y * f);
                float tv = hsvColor.Z * (1 - hsvColor.Y * (1 - f));
                switch (i)
                {
                    case 0:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = tv;
                        rgbColor.Z = pv;
                        break;
                    case 1:
                        rgbColor.X = qv;
                        rgbColor.Y = hsvColor.Z;
                        rgbColor.Z = pv;
                        break;
                    case 2:
                        rgbColor.X = pv;
                        rgbColor.Y = hsvColor.Z;
                        rgbColor.Z = tv;
                        break;
                    case 3:
                        rgbColor.X = pv;
                        rgbColor.Y = qv;
                        rgbColor.Z = hsvColor.Z;
                        break;
                    case 4:
                        rgbColor.X = tv;
                        rgbColor.Y = pv;
                        rgbColor.Z = hsvColor.Z;
                        break;
                    case 5:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = pv;
                        rgbColor.Z = qv;
                        break;
                    case 6:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = tv;
                        rgbColor.Z = pv;
                        break;
                    case -1:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = pv;
                        rgbColor.Z = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        Debug.Assert(false, "color conversion messed up!");
                        rgbColor.X = rgbColor.Y = rgbColor.Z = hsvColor.Z;
                        break;
                }
            }
            return rgbColor;
        }

        public static Vector3 RGBToHSV(Vector3 rgbColor)
        {
            Vector3 hsvColor = new Vector3();
            float min, max, delta;

            min = rgbColor.X < rgbColor.Y ? rgbColor.X : rgbColor.Y;
            min = min < rgbColor.Z ? min : rgbColor.Z;

            max = rgbColor.X > rgbColor.Y ? rgbColor.X : rgbColor.Y;
            max = max > rgbColor.Z ? max : rgbColor.Z;

            hsvColor.Z = max;
            delta = max - min;

            if (delta < 0.00001f)
            {
                hsvColor.Y = 0.0f;
                hsvColor.X = 0.0f;
                return hsvColor;
            }

            if (max > 0.0f)
            {
                hsvColor.Y = (delta / max);
            }
            else
            {
                hsvColor.Y = 0.0f;
                hsvColor.X = 0.0f;
                return hsvColor;
            }

            if (rgbColor.X >= max)
                hsvColor.X = (rgbColor.Y - rgbColor.Z) / delta;
            else if (rgbColor.Y >= max)
                hsvColor.X = 2.0f + (rgbColor.Z - rgbColor.X) / delta;
            else
                hsvColor.X = 4.0f + (rgbColor.X - rgbColor.Y) / delta;

            hsvColor.X /= 6.0f;

            if (hsvColor.X < 0.0f)
                hsvColor.X += 1.0f;

            return hsvColor;
        }
    }
}
