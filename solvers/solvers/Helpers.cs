using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solvers
{
    public static class Helpers
    {
        /// <summary>
        /// Provides an iterator that returns Fibonacci numbers.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> FibonnaciNums()
        {
            var numbers = new List<int>(){ 0, 1 };
            while (true)
            {
                numbers.Add(numbers[0] + numbers[1]);
                numbers.RemoveAt(0);
                yield return numbers[0];
            }
        }

        /// <summary>
        /// Provides an iterator that returns prime numbers up to maxVal.
        /// </summary>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static IEnumerable<int> PrimesUpTo(int maxVal)
        {
            BitArray primes = new BitArray(maxVal);
            primes.SetAll(true);
            primes.Set(0, false);
            primes.Set(1, false);
            int i = 0;
            for (; i*i < maxVal; ++i)
            {
                if (primes.Get(i))
                {
                    for(int j = i*2; j < maxVal; j+=i)
                    {
                        primes.Set(j, false);
                    }
                    yield return i;
                }
            }
            for(; i < maxVal; ++i)
            {
                if (primes.Get(i))
                    yield return i;
            }
        }

        public static bool IsPalindrome(int number)
        {
            string num = number.ToString();
            for(int i = 0; i < num.Length/2; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
