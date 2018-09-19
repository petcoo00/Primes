using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{

    public class MultiplicationTable : MathTable
    {
        private Func<object, object, object> _multiplication;

        public MultiplicationTable(
            List<object> rows,
            List<object> columns, 
            Func<object, object, object> multiplication,
            Func<object, string> formatter
            ) : base(
                rows.Select(i => i.ToString()).ToList(),
                columns.Select(i => i.ToString()).ToList(),
                formatter)
        {
            _multiplication = multiplication;
            _data = new object[rows.Count, columns.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < columns.Count; j++)
                {
                    _data[i, j] = multiplication(rows[i], columns[j]);
                }
            }
        }

        public static MathTable CreatePrimeMultiplicationTable(int n)
        {
            List<object> primes = new List<object>();
            Func<object, object, object> multiplier = (o1, o2) => (int)o1 * (int)o2;
            Func<object, string> formatter = (o) => o.ToString();

            for (int i = 0; i < n; i++) primes.Add(PrimeGenerator.PrimeNumber(i));

            return new MultiplicationTable(primes, primes, multiplier, formatter);
        }
    }
}
