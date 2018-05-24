using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public static IEnumerable<long> AbundantNumbersUpTo(long maxVal)
        {
            long i = 0;
            for (; i < maxVal; ++i)
            {
                if (GetFactors(i, false).Sum() > i)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<long> NotSummableByUpTo(List<long> numbers, long limit)
        {
            BitArray sums = new BitArray((int)limit);
            numbers.Sort();
            for(int i = 0; i < numbers.Count; ++i)
            {
                for(int j = i; j < numbers.Count; ++j)
                {
                    if(numbers[i] + numbers[j] < limit)
                        sums.Set((int)(numbers[i] + numbers[j]), true);
                }
            }
            for(int i = 0; i < limit; ++i)
            {
                if (!sums.Get(i))
                {
                    yield return i;
                }
            }
            
        }

        public static IEnumerable<IEnumerable<T>> GetKCombsWithRept<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetKCombsWithRept(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) >= 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
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

        public static int SumDigits(double input)
        {
            return input.ToString().Select(c => (c - '0')).Sum();
        }

        public static long SumDigits(BigInteger input)
        {
            return input.ToString().Select(c => (long)(c - '0')).Sum();
        }

        /// <summary>
        /// Sum of the letter-values, where A = 1, case insensitive
        /// </summary>
        /// <param name="word"></param>
        /// <returns>The sum of the letter values</returns>
        public static long SumLetters(string word)
        {
            return word.ToLower().Select(c => (c - 'a' + 1)).Sum();
        }

        public static IEnumerable<long> TriangleNumbers()
        {
            long index = 1;
            long triangle = 0;
            while (true)
            {
                triangle += index;
                index++;
                yield return triangle;
            }
        }

        /// <summary>
        /// Returns an iterator that will provide all factors for a number.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="includeSelf">Set to false to exclude 'num' from the output.</param>
        /// <returns></returns>
        public static IEnumerable<long> GetFactors(long num, bool includeSelf = true)
        {
            for (long i = 1; i * i <= num; ++i)
            {
                if (num % i == 0)
                {
                    if (includeSelf || i != num)
                        yield return i;

                    if (i * i != num && (includeSelf || i != 1))
                    {
                        yield return num / i;
                    }
                }
            }
        }

        public static long CollatzSequence(long start, long count = 0)
        {
            while (start > 1)
            {
                count++;
                if (start % 2 == 0)
                {
                    start /= 2;
                }
                else
                {
                    start *= 3;
                    start++;
                }
            }
            return count;
        }

        public static Node BuildTree(List<List<int>> data, out long maxVal, bool maxSumPath = false)
        {
            Node Root = new Node(data[0][0]);
            List<Node> thisRow = new List<Node>();
            List<Node> lastRow = new List<Node>();
            lastRow.Add(Root);
            for (int i = 0; i < data.Count - 1; ++i)
            {
                int nextRowCount = data[i + 1].Count;
                for (int j = 0; j < nextRowCount; ++j)
                {
                    Node input = new Node(data[i + 1][j]);
                    thisRow.Add(input);
                    long leftSum, rightSum;
                    leftSum = rightSum = 0;
                    if (j < nextRowCount - 1)
                    {
                        if (maxSumPath)
                            leftSum = lastRow[j].Data + input.Data;
                        lastRow[j].Left = input;
                    }
                    if (j - 1 >= 0)
                    {
                        if (maxSumPath)
                            rightSum = lastRow[j - 1].Data + input.Data;
                        lastRow[j - 1].Right = input;
                    }
                    if (maxSumPath)
                        input.Data = leftSum > rightSum ? leftSum : rightSum;
                }
                lastRow = new List<Node>(thisRow);
                thisRow.Clear();
            }
            maxVal = lastRow.Max(node => node.Data);
            return Root;
        }

        public static List<string> GetPermutations(string input)
        {
            int tail = input.Length - 1;
            return GetPermutations(input.ToCharArray(), 0, tail).ToList();
        }

        private static IEnumerable<string> GetPermutations(char[] input, int swap, int tail)
        {
            if(swap == tail)
            {
                yield return input.ToString();
            }
            else
            {
                for(int i = swap; i <= tail; ++i)
                {
                    SwapChars(ref input[swap], ref input[tail]);
                    GetPermutations(input, swap + 1, tail);
                    SwapChars(ref input[swap], ref input[tail]);
                }
            }
        }

        private static void SwapChars(ref char a, ref char b)
        {
            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }


    }

    public class Node
    {
        public long Data;
        public Node Left;
        public Node Right;
        public Node() { }
        public Node(long data)
        {
            Data = data;
        }
    }
}
