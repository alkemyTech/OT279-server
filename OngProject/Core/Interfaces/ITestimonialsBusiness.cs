using OngProject.Core.Models.DTOs.TestimonialDTO;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsBusiness
    {
        Task<List<Testimonials>> GetAll();
        Task<Testimonials> GetById(int id);
        Task<Testimonials> Insert(TestimonialInsertDto testimonialsDto);
        Task<bool> Delete(int id);
        Task<Testimonials> Update(int id, Testimonials testimonials);
    }
}
