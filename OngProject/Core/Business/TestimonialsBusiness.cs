using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.TestimonialDTO;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class TestimonialsBusiness : ITestimonialsBusiness
    {
        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.List<Testimonials>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Testimonials> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Testimonials> Insert(TestimonialInsertDto testimonialsDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<Testimonials> Update(int id, Testimonials testimonials)
        {
            throw new System.NotImplementedException();
        }
    }
}
