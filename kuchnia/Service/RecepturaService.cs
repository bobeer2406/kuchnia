using kuchnia.Service;
using System.Text.Json;

namespace kuchnia.Service
{
    public class RecepturaService
    {
            private readonly HttpClient _http;

            public RecepturaService(HttpClient http)
            {
                _http = http;
            }

            public async Task<List<Receptura>> PobierzRecepturyAsync(string url)
            {
                try
                {
                    var json = await _http.GetStringAsync(url);
                    var receptury = JsonSerializer.Deserialize<List<Receptura>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return receptury ?? new List<Receptura>();
                }
                catch (Exception ex)
                {
                    // Możesz dodać logowanie błędu tutaj
                    return new List<Receptura>();
                    string status = $"Błąd podczas ładowania danych: {ex.Message}";
                }
            }
        }
    }
namespace kuchnia.Service
{
        public class Receptura
        {
            public string nazwa { get; set; }
            public List<string> skladniki { get; set; }
            public List<string> zalewa { get; set; }
            public string przygotowanie { get; set; }
        }
    }
}
}
