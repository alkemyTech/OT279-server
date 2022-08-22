using OngProject.Entities;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        // Lista de repositorios a implementar
        IRepository<Role> _roleRepository { get; }

        Task<int> Complete();
    }
}
