using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        public IRepository<Testimonials> _TestimonialsRepository;
        public UnitOfWork(OngDbContext context)
        {
            _context = context;
        }

        public IRepository<Testimonials> TestimonialRepository
        {
            get
            {
                if (_TestimonialsRepository == null)
                {
                    _TestimonialsRepository = new Repository<Testimonials>(_context);
                }
                return _TestimonialsRepository;
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
