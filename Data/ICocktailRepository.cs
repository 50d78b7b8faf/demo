namespace Web.Data
{
    public interface ICocktailRepository
    {
        Task AddAsync(Cocktail cocktail);
    }
}
