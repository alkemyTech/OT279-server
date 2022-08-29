
using OngProject.Entities;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        // Lista de repositorios a implementar
        public IRepository<Role> RoleRepository { get; }
        public IRepository<Organization> OrganizationRepository { get; }
        public IRepository<Members> MembersRepository { get; }
        public IRepository<User> UserRepository { get; }

        public IRepository<Slides> SlidesRepository { get; }

        public IRepository<Category> CategoriesRepository { get; }
        public IRepository<Contacts> ContactsRepository { get; }

        IRepository<News> NewsRepository { get; }
        IRepository<Testimonials> TestiomonialsRepository { get; }
        IRepository<Activities> ActivitiesRepository { get; }
        IRepository<Comments> CommentsRepository { get; }

        Task<int> Complete();
        void SaveChanges();
    }
}
