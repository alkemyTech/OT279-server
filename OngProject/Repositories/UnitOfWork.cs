using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        private CategoriesRepository _categoriesRepository;

        public UnitOfWork(OngDbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public CategoriesRepository CategoriesRepo
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new CategoriesRepository(_context);
                }
                return _categoriesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
