using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsService
    {
        Task<List<Testimonials>> GetAll();
        Task<Testimonials> GetById(int id);
        Task<Testimonials> Insert(Testimonials testimonials);
        Task<bool> Delete(int id);
        Task<Testimonials> Update(int id, Testimonials testimonials);
    }
}
