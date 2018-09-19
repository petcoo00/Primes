using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public class MathTable
    {
        protected List<string> _rowNames;
        protected List<string> _colNames;
        protected object[,] _data;
        private Func<object, string> _formatter;
        private int? _greatestWidth = null;

        public MathTable(
            List<string> rowNames, 
            List<string> colNames,
            Func<object, string> formatter = null
            )
        {
            _rowNames = rowNames;
            _colNames = colNames;
            _formatter = formatter;
        }

        private int GreatestWidth()
        {
            if (!_greatestWidth.HasValue)
            {
                int greatest = 0;

                foreach (var s in _rowNames)
                {
                    if (s.Length > greatest) greatest = s.Length;
                }

                foreach (var s in _colNames)
                {
                    if (s.Length > greatest) greatest = s.Length;
                }

                for (int i = 0; i < _rowNames.Count; i++)
                {
                    for (int j = 0; j < _colNames.Count; j++)
                    {
                        string f = FormattedValue(i, j);
                        if (f.Length > greatest) greatest = f.Length;
                    }
                }

                _greatestWidth = greatest;
            }

            return _greatestWidth.Value;
        }

        public string FormattedValue(int row, int col)
        {
            if (null != _rowNames && 
                null != _colNames &&
                null != _data &&
                _rowNames.Count > row &&
                _colNames.Count > col)
            {
                object result = _data[row, col];

                if (null != result)
                {
                    return null != _formatter ? _formatter(result) : result.ToString();
                }
            }

            return string.Empty;
        }

        public string ColNameAt(int index)
        {
            return index < _colNames.Count ? _colNames[index] : string.Empty;
        }

        public string RowNameAt(int index)
        {
            return index < _rowNames.Count ? _rowNames[index] : string.Empty;
        }

        public List<string> AsListOfStrings()
        {
            string delim = "|";
            List<string> result = new List<string>();
            int greatestWidth = GreatestWidth();
            string formatted(string s) => " " + s.PadRight(greatestWidth, ' ') + " ";

            // Header row
            string headerRow = formatted("");
            foreach (var c in _colNames) { headerRow += delim + formatted(c); }
            result.Add(headerRow);

            // Divider
            result.Add("".PadRight((_colNames.Count + 1) * (greatestWidth + 2) + _colNames.Count, '-'));

            // Table row names and data
            for (int i = 0; i < _rowNames.Count; i++)
            {
                string rowString = formatted(_rowNames[i]);
                for (int j = 0; j < _colNames.Count; j++) rowString += delim + formatted(FormattedValue(i, j));
                result.Add(rowString);
            }

            return result;
        }
    }
}
