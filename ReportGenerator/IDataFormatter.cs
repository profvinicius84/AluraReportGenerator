using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    internal interface IDataFormatter
    {
        string FormatData(string input);
    }
}
