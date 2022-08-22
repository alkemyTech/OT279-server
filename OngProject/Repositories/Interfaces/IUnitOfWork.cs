using System;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        // Lista de repositorios a implementar
        IRepository<Testimonials> TestimonialRepository { get; }

        Task<int> Complete();
    }
}
