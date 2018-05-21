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
                if(MagicNumber%num == 0 && num > MaxPrime)
                {
                    MaxPrime = num;
                }
            }
            Console.WriteLine("Largest Prime Factor: " + MaxPrime);
        }
    }
}
