using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        private IRepository<Organization> _organizationRepository;

        public UnitOfWork(OngDbContext context)
        {
            _context = context;
        }
        
        public IRepository<Organization> OrganizationRepository
        {
            get
            {
                if (_organizationRepository == null)
                {
                    _organizationRepository = new Repository<Organization>(_context);
                }
                return _organizationRepository;
            }
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
    }
}
