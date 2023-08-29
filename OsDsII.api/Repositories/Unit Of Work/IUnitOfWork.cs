//using OsDsII.api.Data;

namespace OsDsII.api.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}