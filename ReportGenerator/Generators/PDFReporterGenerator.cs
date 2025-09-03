using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Generators
{
    public class PDFReporterGenerator: ReportGeneratorBase
    {
        
        public PDFReporterGenerator(List<Dictionary<string, string>> input) :base(input) { }

        /// <summary>
        /// Generates a PDF report based on the provided input data, title, headline, and footer.
        /// </summary>
        /// <remarks>This method creates a PDF file named "report.pdf" in the current working directory.
        /// The report includes: <list type="bullet"> <item><description>An optional title displayed at the top of the
        /// document.</description></item> <item><description>An optional headline displayed below the
        /// title.</description></item> <item><description>A table containing the input data, with column headers
        /// derived from the keys of the first record.</description></item> <item><description>An optional footer
        /// displayed at the bottom of the document.</description></item> </list> The method throws an exception if the
        /// input data is null or empty. The generated PDF file's full path is returned as the result.</remarks>
        /// <returns>The full path to the generated PDF file.</returns>
        /// <exception cref="Exception">Thrown if the input data is null or contains no records.</exception>
        public override string GenerateReport()
        {
            if (Input == null || Input.Count == 0)
                throw new Exception("Input de dados invalido");

            using (PdfWriter writer = new PdfWriter("report.pdf"))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (iText.Layout.Document document = new iText.Layout.Document(pdf))
            {

                if (!string.IsNullOrWhiteSpace(Title))
                {
                    var title = new iText.Layout.Element.Paragraph(Title)
                        .SetFontSize(20)
                        .SetBold()
                        .SetMarginBottom(10);
                    document.Add(title);
                }

                if (!string.IsNullOrWhiteSpace(HeadLine))
                {
                    var headline = new iText.Layout.Element.Paragraph(HeadLine)
                        .SetFontSize(16)
                        .SetItalic()
                        .SetMarginBottom(10);
                    document.Add(headline);
                }

                Table table = new Table(Input.First().Keys.Count);

                foreach (var header in Input.First().Keys)
                {
                    table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetBold()));
                }

                foreach (var record in Input)
                {
                    foreach (var value in record.Values)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(value)));
                    }
                }

                document.Add(table);

                if (!string.IsNullOrWhiteSpace(FooterLine))
                {
                    var footer = new iText.Layout.Element.Paragraph(FooterLine)
                        .SetFontSize(12)
                        .SetMarginTop(10);
                    document.Add(footer);
                }
            }

            return Path.GetFullPath("report.pdf");
        }
    }
}
