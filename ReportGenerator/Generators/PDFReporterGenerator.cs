using iText.Kernel.Pdf;
using iText.Layout.Element;

namespace ReportGenerator.Generators;

/// <summary>
/// Gera relatórios em PDF com base nos dados de entrada e metadados
/// (título, manchete e rodapé).
/// </summary>
public class PDFReporterGenerator: ReportGeneratorBase
{
    /// <summary>
    /// Inicializa uma nova instância do gerador de relatórios em PDF.
    /// </summary>
    /// <param name="input">Lista de registros com pares chave/valor.</param>
    public PDFReporterGenerator(List<Dictionary<string, string>> input) :base(input) { }

    /// <summary>
    /// Gera um relatório PDF com base nos dados fornecidos.
    /// </summary>
    /// <remarks>
    /// Este método cria um arquivo PDF chamado "report.pdf" no diretório de trabalho atual.
    /// O relatório inclui:
    /// <list type="bullet">
    /// <item><description>Um título opcional exibido no topo do documento.</description></item>
    /// <item><description>Uma manchete (subtítulo) opcional exibida abaixo do título.</description></item>
    /// <item><description>Uma tabela contendo os dados de entrada, com cabeçalhos derivados das chaves do primeiro registro.</description></item>
    /// <item><description>Um rodapé opcional exibido no final do documento.</description></item>
    /// </list>
    /// Lança uma exceção se a entrada for nula ou vazia.
    /// </remarks>
    /// <returns>O caminho completo do arquivo PDF gerado.</returns>
    /// <exception cref="Exception">Lançada se a entrada de dados for nula ou não contiver registros.</exception>
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
