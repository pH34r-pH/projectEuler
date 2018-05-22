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
            int prime = (int)Helpers.PrimesUpTo(200000).Skip(10000).First();
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
            int[,] input = new int[,]{{08,02,22,97,38,15,00,40,00,75,04,05,07,78,52,12,50,77,91,08 },
                                        {49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,04,56,62,00},
                                        {81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,03,49,13,36,65},
                                        {52,70,95,23,04,60,11,42,69,24,68,56,01,32,56,71,37,02,36,91},
                                        {22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80},
                                        {24,47,32,60,99,03,45,02,44,75,33,53,78,36,84,20,35,17,12,50},
                                        {32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70},
                                        {67,26,20,68,02,62,12,20,95,63,94,39,63,08,40,91,66,49,94,21},
                                        {24,55,58,05,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72},
                                        {21,36,23,09,75,00,76,44,20,45,35,14,00,61,33,97,34,31,33,95},
                                        {78,17,53,28,22,75,31,67,15,94,03,80,04,62,16,14,09,53,56,92},
                                        {16,39,05,42,96,35,31,47,55,58,88,24,00,17,54,24,36,29,85,57},
                                        {86,56,00,48,35,71,89,07,05,44,44,37,44,60,21,58,51,54,17,58},
                                        {19,80,81,68,05,94,47,69,28,73,92,13,86,52,17,77,04,89,55,40},
                                        {04,52,08,83,97,35,99,16,07,97,57,32,16,26,26,79,33,27,98,66},
                                        {88,36,68,87,57,62,20,72,03,46,33,67,46,55,12,32,63,93,53,69},
                                        {04,42,16,73,38,25,39,11,24,94,72,18,08,46,29,32,40,62,76,36},
                                        {20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,04,36,16},
                                        {20,73,35,29,78,31,90,01,74,31,49,71,48,86,81,16,23,57,05,54},
                                        {01,70,54,71,83,51,54,69,16,92,33,48,61,43,52,01,89,19,67,48}};
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
        /// </summary>
        public static void P12()
        {
            
        }
    }
}
