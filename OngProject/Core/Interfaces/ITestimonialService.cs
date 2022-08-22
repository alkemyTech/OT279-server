using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialService
    {
        Task<IEnumerable<Testimonials>> GetAll();
        Task<Testimonials> GetById(int id);
        Task Insert(Testimonials entity);
        Task Delete(int id);
        Task Update(int id, Testimonials entity);
    }
}
