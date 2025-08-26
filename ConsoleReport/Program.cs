using ReportGenerator;

List<Dictionary<string, string>> data = new()
{
    new Dictionary<string, string>
    {
        { "Nome", "Alice" },
        { "Idade", "30" },
        { "Cidade", "São Paulo" }
    },
    new Dictionary<string, string>
    {
        { "Nome", "Roberto" },
        { "Idade", "25" },
        { "Cidade", "Salvador" }
    },
    new Dictionary<string, string>
    {
        { "Nome", "Carlos" },
        { "Idade", "35" },
        { "Cidade", "Rio de Janeiro" }
    }
};

ReporterGenerator reporterGenerator = new ReporterGenerator(data);

string caminhoArquivo = reporterGenerator.GenerateReport();

Console.WriteLine("O arquivo foi salvo em: " + caminhoArquivo);