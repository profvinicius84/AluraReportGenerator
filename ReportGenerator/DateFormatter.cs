using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    internal class DateFormatter: IDataFormatter
    {
        public string FormatData(string input)
        {
            if (DateTime.TryParse(input, out DateTime date))
            {
                return date.ToString("dd/MM/yyyy");
            }
            return input;
        }
    }
}
