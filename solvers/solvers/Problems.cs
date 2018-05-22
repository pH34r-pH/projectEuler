using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solvers
{
    public static class Problems
    {
        /// <summary>
        /// Finds the sum of all numbers below 1000 that are a multiple of either 3 or 5.
        /// </summary>
        public static void P1()
        {
            int sum = Enumerable.Range(0, 1000).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
            Console.WriteLine("Sum: " + sum);
        }

        /// <summary>
        /// The sum of the even-numbered fibonacci numbers below four million
        /// </summary>
        public static void P2()
        {
            int sum = Helpers.FibonnaciNums().Where(x => x % 2 == 0).TakeWhile(c => c < 4000000).Sum();
            Console.WriteLine("Sum: " + sum);
        }

        /// <summary>
        /// The largest prime factor of the number 600851475143
        /// </summary>
        public static void P3()
        {
            double MagicNumber = 600851475143;
            int MaxPrime = 0;
            foreach (int num in Helpers.PrimesUpTo((int)Math.Ceiling(Math.Sqrt(MagicNumber))))
            {
                if (MagicNumber % num == 0 && num > MaxPrime)
                {
                    MaxPrime = num;
                }
            }
            Console.WriteLine("Largest Prime Factor: " + MaxPrime);
        }

        /// <summary>
        /// The largest number that is a product of two 3-digit numbers and a palindrome
        /// </summary>
        public static void P4()
        {
            int i, j, max;
            max = 0;
            for (i = 999; i > 0; --i)
            {
                for (j = 999; j > 0; --j)
                {
                    if (Helpers.IsPalindrome(i * j) && i * j > max)
                    {
                        max = i * j;
                    }

                }
            }
            Console.WriteLine("Largest Palindrome: " + max);
        }

        /// <summary>
        /// The smallest number evenly divisible by every number 1-20
        /// </summary>
        public static void P5()
        {
            int number = 1;
            foreach (int num in Enumerable.Range(1, 20))
            {
                number = Helpers.LCM(number, num);
            }
            Console.WriteLine("The Number: " + number);
        }

        /// <summary>
        /// The difference between the sum of the squares and the square of the sum of the numbers 1-100
        /// </summary>
        public static void P6()
        {
            int SumofSquares = Enumerable.Range(1, 100).Select(x => x * x).Sum();
            int SquareofSum = (int)Math.Pow((double)Enumerable.Range(1, 100).Sum(), 2);
            Console.WriteLine("The difference is: {0}", SquareofSum - SumofSquares);
        }

        /// <summary>
        /// The 10001st prime number
        /// </summary>
        public static void P7()
        {
            int prime = Helpers.PrimesUpTo(int.MaxValue).Skip(10000).First();
            Console.WriteLine("The 10001st prime is: " + prime);
        }

        /// <summary>
        /// Find the 13 adjacent digits with the largest product
        /// </summary>
        public static void P8()
        {
            string input = "731671765313306249192251196744265747423553491949349" +
                "698352031277450632623957831801698480186947885184385861560789112" +
                "9494954595017379583319528532088055111254069874715852386305071569" +
                "3290963295227443043557668966489504452445231617318564030987111217" +
                "22383113622298934233803081353362766142828064444866452387493035890" +
                "72962904915604407723907138105158593079608667017242712188399879790" +
                "879227492190169972088809377665727333001053367881220235421809751254" +
                "5405947522435258490771167055601360483958644670632441572215539753697" +
                "81797784617406495514929086256932197846862248283972241375657056057490" +
                "261407972968652414535100474821663704844031998900088952434506585412275" +
                "886668811642717147992444292823086346567481391912316282458617866458" +
                "3591245665294765456828489128831426076900422421902267105562632111110" +
                "9370544217506941658960408071984038509624554443629812309878799272442" +
                "84909188845801561660979191338754992005240636899125607176060588611646" +
                "71094050775410022569831552000559357297257163626956188267042825248360" +
                "0823257530420752963450";

            long max = 0;
            long running = 1;
            int i = 0;
            int window = 13;

            // This is only safe because the first 13 digits contain no zeroes
            for (; i < window; ++i)
            {
                running *= (input[i] - '0');
            }

            max = running;
            for (; i < input.Length; ++i)
            {
                running *= (input[i] == '0') ? 1 : (input[i] - '0');
                running /= (input[i - window] == '0') ? 1 : (input[i - window] - '0');

                if (running > max && !input.Skip(i - window).Take(window).Contains('0'))
                {
                    max = running;
                }
            }
            Console.WriteLine("The max product is: " + max);
        }

        /// <summary>
        /// The pythagorean triplet such that the sum of the sides of the triangle is 1000
        /// </summary>
        public static void P9()
        {

        }
    }
}
