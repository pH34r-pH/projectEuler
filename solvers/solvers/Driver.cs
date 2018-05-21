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
            MethodInfo Solution;
            do {
                Console.WriteLine("Enter the number of the problem to solve: ");
                string Problem = "P" + Console.ReadLine();
                Solution = typeof(Problems).GetMethod(Problem);

                if(Solution == null) { Console.WriteLine("Sorry, that's not a valid problem."); }
            } while (Solution == null);

            Console.WriteLine("Solving...");
            Solution.Invoke(null, null);
            Console.WriteLine("Press the enter key to quit.");
            Console.ReadLine();
        }
    }
}
