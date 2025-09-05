namespace ReportGenerator.Util;

/// <summary>
/// Define o contrato para formatadores de dados.
/// </summary>
internal interface IDataFormatter
{
    /// <summary>
    /// Formata o valor de entrada e retorna a representação formatada.
    /// </summary>
    /// <param name="input">Valor de entrada a ser formatado.</param>
    /// <returns>O valor formatado.</returns>
    string FormatData(string input);
}
