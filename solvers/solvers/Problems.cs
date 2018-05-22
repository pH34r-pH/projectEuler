﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            int prime = (int)Helpers.PrimesUpTo(200000).Skip(10000).First();
            Console.WriteLine("The 10001st prime is: " + prime);
        }

        /// <summary>
        /// Find the 13 adjacent digits with the largest product
        /// </summary>
        public static void P8()
        {
            string input = Inputs.Problem8;

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
        /// It's basically a brute force solution with small optimizations because there just isn't a huge problem space to deal with
        /// </summary>
        public static void P9()
        {
            for (int i = 1000; i > 0; --i)
            {
                for (int j = 1000 - i; j > 0; --j)
                {
                    if (i + j < 1000)
                    {
                        int k = 1000 - i - j;
                        if ((k * k) + (j * j) == (i * i))
                        {
                            Console.WriteLine("The triangle is {0}, {1}, {2}; the product of the sides is {3}", i, j, k, i * j * k);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The sum of the primes less than two million
        /// </summary>
        public static void P10()
        {
            long sum = Helpers.PrimesUpTo(5000000).Where(x => x < 2000000).Sum();
            Console.WriteLine("The sum is: " + sum);
        }

        /// <summary>
        /// The greatest product of 4 adjacent numbers 
        /// </summary>
        public static void P11()
        {
            int[,] input = Inputs.Problem11;
            int max = 0;
            for (int i = 0; i < 17; ++i)
            {
                for (int j = 0; j < 17; ++j)
                {
                    int temp = 0;
                    // right
                    temp = input[i, j] * input[i, j + 1] * input[i, j + 2] * input[i, j + 3];
                    max = temp > max ? temp : max;

                    // down
                    temp = input[i, j] * input[i + 1, j] * input[i + 2, j] * input[i + 3, j];
                    max = temp > max ? temp : max;

                    // down-right
                    temp = input[i, j] * input[i + 1, j + 1] * input[i + 2, j + 2] * input[i + 3, j + 3];
                    max = temp > max ? temp : max;

                    // down-left <- needs a check
                    if(j >= 3)
                    {
                        temp = input[i, j] * input[i + 1, j - 1] * input[i + 2, j - 2] * input[i + 3, j - 3];
                        max = temp > max ? temp : max;
                    }
                }
            }
            Console.WriteLine("The max value is: " + max);
        }

        /// <summary>
        /// The first "triangle number" that has more than 500 divisors
        /// Not currently working
        /// </summary>
        public static void P12()
        {
            long triangle = 0;
            foreach(long tryangle in Helpers.TriangleNumbers())
            {
                if (Helpers.GetFactors(tryangle).Count() > 500)
                {
                    triangle = tryangle;
                    break;
                }
            }
            Console.WriteLine("The number is: " + triangle);
        }

        /// <summary>
        /// Find the first 10 digits of the sum of 100 numbers which are 50 digits long
        /// </summary>
        public static void P13()
        {
            BigInteger cheese = new BigInteger();
            foreach(string cheddar in Inputs.Problem13)
            {
                BigInteger mozzarela = BigInteger.Parse(cheddar);
                cheese += mozzarela;
            }
            Console.WriteLine("The first 10 digits are: " + cheese.ToString().Substring(0,10));
        }

        /// <summary>
        /// The starting number under 1 million that produces the longest Collatz sequence
        /// Is it pretty? No, this could be optimized with memoization, but I didn't feel like it and
        /// it still completes in under 10 seconds so
        /// </summary>
        public static void P14()
        {
            long longest = 0;
            int startnum = 0;
            foreach(int val in Enumerable.Range(0, 1000000))
            {
                long length = Helpers.CollatzSequence(val);
                if (length > longest)
                {
                    longest = length;
                    startnum = val;
                }
            }
            Console.WriteLine("The start number is: " + startnum);
        }

        /// <summary>
        /// The number of unique routes in a 20x20 grid, only moving to the right or down
        /// </summary>
        public static void P15()
        {

        }
    }
}
