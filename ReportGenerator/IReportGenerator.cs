using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public interface IReportGenerator
    {
        List<Dictionary<string, string>> Input { get; set; }

        string Title { get; set; }

        string HeadLine { get; set; }
        string FooterLine { get; set; }

        string GenerateReport();
    }
}
