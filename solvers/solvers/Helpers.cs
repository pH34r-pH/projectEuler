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
            var numbers = new List<int>() { 0, 1 };
            while (true)
            {
                numbers.Add(numbers[0] + numbers[1]);
                numbers.RemoveAt(0);
                yield return numbers[0];
            }
        }

        /// <summary>
        /// Provides an iterator that returns prime numbers up to maxVal.
        /// This should be able to handle very large numbers.
        /// </summary>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static IEnumerable<long> PrimesUpTo(long maxVal)
        {
            List<BitArray> primes = new List<BitArray>();
            if (maxVal < int.MaxValue)
            {
                BitArray slot = new BitArray((int)maxVal);
                slot.SetAll(true);
                primes.Add(slot);
            }
            else
            {
                long temp = maxVal;
                while (temp > int.MaxValue)
                {
                    temp -= int.MaxValue;
                    BitArray slot = new BitArray(int.MaxValue);
                    slot.SetAll(true);
                    primes.Add(slot);
                }
                BitArray lastslot = new BitArray((int)temp);
                lastslot.SetAll(true);
                primes.Add(lastslot);
            }

            primes[0].Set(0, false);
            primes[0].Set(1, false);

            long i = 0;
            for (; i * i < maxVal; ++i)
            {
                if (primes[(int)(i / int.MaxValue)].Get((int)(i % int.MaxValue)))
                {
                    for (long j = i * 2; j < maxVal - i; j += i)
                    {
                        primes[(int)(j / int.MaxValue)].Set((int)(j % int.MaxValue), false);
                    }
                    yield return i;
                }
            }
            for (; i < maxVal; ++i)
            {
                if (primes[(int)(i / int.MaxValue)].Get((int)(i % int.MaxValue)))
                    yield return i;
            }
        }

        public static bool IsPalindrome(int number)
        {
            string num = number.ToString();
            for (int i = 0; i < num.Length / 2; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Greatest Common Factor
        /// </summary>
        public static int GCF(int a, int b)
        {
            int temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Least Common Multiple
        /// </summary>
        public static int LCM(int a, int b)
        {
            return (a / GCF(a, b)) * b;
        }

        public static IEnumerable<long> TriangleNumbers()
        {
            long index = 1;
            long triangle = 0;
            while (true)
            {
                triangle += (triangle + index);
                index++;
                yield return triangle;
            }
        }

        public static IEnumerable<long> GetFactors(long num)
        {
            for(long i = 1; i*i <= num; ++i)
            {
                if (num % i == 0)
                {
                    yield return i;
                    if(i*i != num)
                    {
                        yield return num / i;
                    }
                }
            }
        }
    }
}
