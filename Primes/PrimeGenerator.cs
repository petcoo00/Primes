using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public class PrimeGenerator
    {
        private static List<int> _primes = new List<int>() { 2 };

        private static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;

            int divisor = 2;

            while (divisor * 2 <= n)
            {
                if (n % divisor == 0)
                {
                    return false;
                }

                divisor += 2 == divisor ? 1 : 2;
            }

            return true;
        }

        private static int NextPrimeAfter(int i)
        {
            int test = i + 1;

            while (!IsPrime(test))
            {
                test++;
            }

            return test;
        }

        private static void GeneratePrimes(int n)
        {
            int lastPrime = _primes.Last();
            int lastIndex = _primes.Count;

            for (int i = 0; i < n - lastIndex; i++)
            {
                lastPrime = NextPrimeAfter(lastPrime);
                _primes.Add(lastPrime);
            }
        }

        public static int PrimeNumber(int i)
        {
            if (i >= _primes.Count)
            {
                GeneratePrimes(i+1);
            }

            return _primes[i];
        }
    }
}
