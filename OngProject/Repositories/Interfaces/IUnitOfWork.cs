using OngProject.Entities;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        // Lista de repositorios a implementar
        public IRepository<Organization> OrganizationRepository { get; }

        Task<int> Complete();
    }
}
