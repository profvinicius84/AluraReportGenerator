namespace ReportGenerator.Util;

/// <summary>
/// Formatador de datas que converte entradas em uma representação no padrão dd/MM/yyyy
/// quando possível; caso contrário, retorna a entrada original.
/// </summary>
internal class DateFormatter: IDataFormatter
{
    /// <summary>
    /// Tenta converter a entrada em uma data e formatá-la como dd/MM/yyyy.
    /// </summary>
    /// <param name="input">Texto contendo uma data válida ou qualquer outra string.</param>
    /// <returns>
    /// A data formatada (dd/MM/yyyy) quando a conversão for bem-sucedida; caso contrário, o mesmo valor de entrada.
    /// </returns>
    public string FormatData(string input)
    {
        if (DateTime.TryParse(input, out DateTime date))
        {
            return date.ToString("dd/MM/yyyy");
        }
        return input;
    }
}
