using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class ReporterGenerator
    {
        public List<Dictionary<string, string>> Input { get; set; }

        public ReporterGenerator(List<Dictionary<string, string>> input) 
        { 
            Input = input;
        }

        public string GenerateReport()
        {
            if (Input == null || Input.Count == 0)
                throw new Exception("Input de dados invalido");

            StringBuilder report = new StringBuilder();

            string header = string.Join(';', Input.First().Keys);

            report.AppendLine(header);

            foreach (var record in Input)
            {
                string line = string.Join(";", record.Values);
                report.AppendLine(line);
            }

            File.WriteAllText("report.csv", report.ToString());

            return Path.GetFullPath("report.csv");
        }
    }
}
