using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamickeProgramovani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(CheckNonDynamicBruteForce(input));
        }

        // basically brute forcing
        static string CheckNonDynamicBruteForce(string input)
        {
            bool InnerSomething(string text, int start, int end)
            {
                for (int offset = 0; offset < end - start; offset++)
                {
                    if (start + offset > end - offset)
                        break;

                    char cs = text[start + offset];
                    char ce = text[end - offset];

                    if (cs == ce)
                        continue;
                    else
                        return false;
                }
                return true;
            }

            int besti = 0;
            int bestoi = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int oi = i + 1; oi < input.Length - 1; oi++)
                {
                    if (InnerSomething(input, i, oi) && oi - i > bestoi - besti)
                    {
                        besti = i;
                        bestoi = oi;
                    }
                }
            }

            return input.Substring(besti, bestoi - besti);
        }

        // i was lazy to finish this :( - you will see me in few years on a sidewalk next to Kaufland
        static string CheckDynamic(string input)
        {
            throw new NotImplementedException();

            bool[,] cache = new bool[input.Length, input.Length];
            void InnerSoumething(string text, int start, int end)
            {
                
            }

            InnerSoumething(input, 0, input.Length - 1);
        }
    }
}
