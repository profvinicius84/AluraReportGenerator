namespace ReportGenerator.Generators;

/// <summary>
/// Define o contrato para geradores de relatórios com entrada de dados e metadados configuráveis.
/// </summary>
/// <remarks>
/// Implementações desta interface permitem configurar os dados do relatório (lista de registros com pares chave/valor)
/// e metadados como título, manchete e rodapé, gerando um relatório e retornando o caminho do arquivo gerado.
/// </remarks>
public interface IReportGenerator
{
    /// <summary>
    /// Obtém ou define os dados de entrada como uma lista de dicionários, onde cada dicionário representa um registro
    /// com pares chave/valor.
    /// </summary>
    List<Dictionary<string, string>> Input { get; set; }

    /// <summary>
    /// Obtém ou define o título do relatório.
    /// </summary>
    string Title { get; set; }

    /// <summary>
    /// Obtém ou define a manchete (subtítulo) do relatório.
    /// </summary>
    string HeadLine { get; set; }
    
    /// <summary>
    /// Obtém ou define o texto do rodapé do relatório.
    /// </summary>
    string FooterLine { get; set; }

    /// <summary>
    /// Gera o relatório e retorna o caminho completo do arquivo criado.
    /// </summary>
    /// <returns>Uma string contendo o caminho do arquivo do relatório gerado.</returns>
    string GenerateReport();
}
