using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGenerator;

namespace ScreenSound_04
{
    internal class CSVGenerator: CSVReporterGenerator
    {
        public CSVGenerator(List<Dictionary<string, string>> input) : base(input)
        {
        }

        public string GenerateCSV(string fileName)
        {
            GenerateReport();
            File.Move("report.csv", fileName);
            
            return Path.GetFullPath(fileName);
        }
    }
}
