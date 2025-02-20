using Web.DTO;

namespace Web.Services
{
    public interface IApiCocktailService
    {
        Task<List<CocktailDto>?> GetCocktailsAsync(string name);
    }
}
