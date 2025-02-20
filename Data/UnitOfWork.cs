namespace Web.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Lazy<ICocktailRepository> _cocktailRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _cocktailRepository = new Lazy<ICocktailRepository>(() => new CocktailRepository(_context));
        }

        public ICocktailRepository CocktailRepository => _cocktailRepository.Value;

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
