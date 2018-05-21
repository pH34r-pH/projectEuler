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
            int sum = 0;
            for(int i = 0; i < 1000; ++i)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
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
    }
}
