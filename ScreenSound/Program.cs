using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;
using ReportGenerator;
using ScreenSound_04;


using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        List<Dictionary<string, string>> reportData = new List<Dictionary<string, string>>();

        foreach (var musica in musicas)
        {
            var record = new Dictionary<string, string>
            {
                { "Nome", musica.Nome },
                { "Artista", musica.Artista },
                { "Genero", musica.Genero },
                { "Tonalidade", musica.Tonalidade }
            };
            reportData.Add(record);
        }

        CSVGenerator reportGenerator = new CSVGenerator (reportData);

        string local = reportGenerator.GenerateCSV("musicas.csv");

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}