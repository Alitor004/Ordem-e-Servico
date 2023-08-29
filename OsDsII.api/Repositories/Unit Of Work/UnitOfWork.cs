using OsDsII.api.Data;
using Microsoft.EntityFrameworkCore;

namespace OsDsII.api.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(dataContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        } 
    }    
}