using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.IO;

namespace big_numbers_factorial
{
    class  calculate
    {
        static readonly int DegreeOfParallelism = Environment.ProcessorCount;
        
        public static BigInteger Factorial(long x)
        {
            Console.Clear();
            Console.WriteLine("Lütfen Bekleyiniz...");
            var parallelTasks =
                Enumerable.Range(1, DegreeOfParallelism).Select(i => Task.Factory.StartNew(() => Multiply(x, i),TaskCreationOptions.LongRunning)).ToArray();

            Task.WaitAll(parallelTasks);

            BigInteger finalResult = 1;

            foreach (var partialResult in parallelTasks.Select(t => t.Result))
            {
                
                finalResult *= partialResult;
            }
            
            return finalResult;

        }


        public static BigInteger Multiply(long upperBound, int startFrom)
        {
            BigInteger result = 1;

            for (var i = startFrom; i <= upperBound; i += DegreeOfParallelism)
                result *= i;
            return result;
        }
       
    }
}
