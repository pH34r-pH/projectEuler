using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solvers
{
    class Driver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of the problem to solve: ");
            string Problem = "P" + Console.ReadLine();
            Console.WriteLine("Solving...");
            typeof(Problems).GetMethod(Problem).Invoke(null, null);
            Console.WriteLine("Press the enter key to quit.");
            Console.ReadLine();
        }
    }
}
