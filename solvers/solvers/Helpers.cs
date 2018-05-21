using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solvers
{
    public static class Helpers
    {
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
    }
}
