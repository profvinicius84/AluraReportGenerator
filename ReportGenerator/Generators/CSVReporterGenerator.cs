using ReportGenerator.Util;
using System.Text;

namespace ReportGenerator.Generators;

/// <summary>
/// Gera relatórios em formato CSV com base nos dados de entrada e metadados
/// (título, manchete e rodapé).
/// </summary>
public class CSVReporterGenerator: ReportGeneratorBase
{
    /// <summary>
    /// Inicializa uma nova instância do gerador de relatórios CSV.
    /// </summary>
    /// <param name="input">Lista de registros com pares chave/valor.</param>
    public CSVReporterGenerator(List<Dictionary<string, string>> input) : base(input) { }

    /// <summary>
    /// Gera o relatório no formato CSV e salva o arquivo "report.csv" no diretório atual.
    /// </summary>
    /// <remarks>
    /// - Inclui opcionalmente o título e a manchete no início do arquivo.
    /// - Cria o cabeçalho com base nas chaves do primeiro registro.
    /// - Escreve cada linha do corpo com os valores dos registros.
    /// - Inclui opcionalmente o rodapé ao final, bem como a data formatada (dd/MM/yyyy).
    /// </remarks>
    /// <returns>O caminho completo do arquivo CSV gerado.</returns>
    /// <exception cref="Exception">Lançada se a entrada de dados for nula ou vazia.</exception>
    public override string GenerateReport()
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
