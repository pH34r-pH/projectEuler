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
            do
            {
                Console.WriteLine("Enter the number of the problem to solve: ");
                string Problem = "P" + Console.ReadLine();
                Solution = typeof(Problems).GetMethod(Problem);

                if (Solution == null) { Console.WriteLine("Sorry, that's not a valid problem or it hasn't been solved yet."); }
            } while (Solution == null);

            Console.WriteLine("Solving...");
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            Solution.Invoke(null, null);
            timer.Stop();
            Console.WriteLine("Completed in {0}", timer.Elapsed.ToString());
            Console.WriteLine("Press the enter key to quit.");
            Console.ReadLine();
        }
    }
}
