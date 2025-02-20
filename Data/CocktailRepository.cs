namespace Web.Data
{
    public class CocktailRepository : ICocktailRepository
    {
        private readonly ApplicationDbContext _context;

        public CocktailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cocktail cocktail)
        {
            await _context.Cocktails.AddAsync(cocktail);
        }
    }
}
