using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        // Al concrete repositories here.

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;

            // Al concrete repositories here.
        }

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
