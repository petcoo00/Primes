using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeCount = 10;

            if (args.Length == 1)
            {
                if (int.TryParse(args[0], out int i)) primeCount = i;
            }

            var results = MultiplicationTable.CreatePrimeMultiplicationTable(primeCount).AsListOfStrings();

            foreach(var line in results)
            {
                Console.WriteLine(line);
            }

            Console.Read();
        }
    }
}
