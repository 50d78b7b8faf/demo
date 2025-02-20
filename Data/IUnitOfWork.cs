namespace Web.Data
{
    public interface IUnitOfWork
    {
        ICocktailRepository CocktailRepository { get; }
        Task CompleteAsync();
    }
}
