using Newtonsoft.Json;
using Web.DTO;

namespace Web.Services
{
    public class ApiCocktailService : IApiCocktailService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.api-ninjas.com/v1/cocktail";
        private const string ApiKey = "";

        public ApiCocktailService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
        }

        public async Task<List<CocktailDto>?> GetCocktailsAsync(string name)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}?name={name}");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var cocktails = JsonConvert.DeserializeObject<List<CocktailDto>>(responseContent);
                return cocktails;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error en la solicitud: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}");
                return null;
            }
        }
    }
}
