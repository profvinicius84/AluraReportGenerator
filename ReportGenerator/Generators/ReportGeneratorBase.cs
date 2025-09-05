namespace ReportGenerator.Generators;

/// <summary>
/// Classe base abstrata para geradores de relatórios, fornecendo propriedades comuns
/// e um contrato para geração de relatórios.
/// </summary>
public abstract class ReportGeneratorBase : IReportGenerator
{
    /// <summary>
    /// Dados de entrada do relatório. Cada item da lista representa um registro, composto
    /// por pares chave/valor.
    /// </summary>
    public List<Dictionary<string, string>> Input { get; set; }

    /// <summary>
    /// Título do relatório.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Manchete (subtítulo) do relatório.
    /// </summary>
    public string HeadLine { get; set; }

    /// <summary>
    /// Texto do rodapé do relatório.
    /// </summary>
    public string FooterLine { get; set; }

    /// <summary>
    /// Cria uma nova instância do gerador de relatórios base.
    /// </summary>
    /// <param name="input">Lista de registros com pares chave/valor que serão utilizados no relatório.</param>
    public ReportGeneratorBase(List<Dictionary<string, string>> input)
    {
        Input = input;
    }

    /// <summary>
    /// Gera o relatório e retorna o caminho completo do arquivo criado.
    /// </summary>
    /// <returns>O caminho completo do arquivo do relatório gerado.</returns>
    public abstract string GenerateReport();
}
