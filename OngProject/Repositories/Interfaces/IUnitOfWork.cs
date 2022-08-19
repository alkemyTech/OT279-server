using System;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // All concrete repositories here

        Task<int> Complete();
    }
}
