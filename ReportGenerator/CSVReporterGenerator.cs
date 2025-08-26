using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class CSVReporterGenerator: IReportGenerator
    {
        public List<Dictionary<string, string>> Input { get; set; }

        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string FooterLine { get; set; }
        public CSVReporterGenerator(List<Dictionary<string, string>> input) 
        { 
            Input = input;
        }

        public string GenerateReport()
        {
            if (Input == null || Input.Count == 0)
                throw new Exception("Input de dados invalido");

            StringBuilder report = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(Title))
            {
                report.AppendLine(Title);
                report.AppendLine("");
            }

            if (!string.IsNullOrWhiteSpace(HeadLine))
            {
                report.AppendLine(HeadLine);
                report.AppendLine("");
            }

            string header = string.Join(';', Input.First().Keys);

            report.AppendLine(header);

            foreach (var record in Input)
            {
                string line = string.Join(";", record.Values);
                report.AppendLine(line);
            }

            if (!string.IsNullOrWhiteSpace(FooterLine))
            {
                report.AppendLine("");
                report.AppendLine(FooterLine);
            }

            DateFormatter dateFormatter = new DateFormatter();

            report.Append(dateFormatter.FormatData(DateTime.Now.ToString()));

            File.WriteAllText("report.csv", report.ToString(), Encoding.UTF8);

            return Path.GetFullPath("report.csv");
        }
    }
}
