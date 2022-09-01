using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsBusiness
    {
        Task<List<Testimonials>> GetAll();
        Task<Testimonials> GetById(int id);
        Task<Testimonials> Insert(Testimonials testimonials);
        public Task<bool> DeleteTestimonials(Testimonials testimonials);
        Task<Testimonials> Update(int id, Testimonials testimonials);
    }
}
