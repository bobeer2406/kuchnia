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

        // Metoda generyczna do pobierania dowolnych danych JSON
        public async Task<List<T>> PobierzDaneAsync<T>(string url)
        {
            try
            {
                var json = await _http.GetStringAsync(url);

                var dane = JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return dane ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas ładowania danych z {url}: {ex.Message}");
                return new List<T>();
            }
        }

        // Stara metoda - dla kompatybilności
        public async Task<List<Receptura>> PobierzRecepturyAsync(string url)
        {
            return await PobierzDaneAsync<Receptura>(url);
        }
        public async Task<List<Przepis>> PobierzPrzepisAsync(string url)
        {
            return await PobierzDaneAsync<Przepis>(url);
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
        public class Przepis
        {
        public string nazwa { get; set; }
        public string Kategoria { get; set; }
        public List<string> skladniki { get; set; }
        public List<string> sposob_przygotowania { get; set; }
        public string Temperatura_pieczenia { get; set; }
        public string Czas_pieczenia { get; set; }
        }

 }


