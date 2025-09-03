using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Generators
{
    public abstract class ReportGeneratorBase : IReportGenerator
    {
        public List<Dictionary<string, string>> Input { get; set; }
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string FooterLine { get; set; }
        public ReportGeneratorBase(List<Dictionary<string, string>> input)
        {
            Input = input;
        }

        public abstract string GenerateReport();
    }
}
