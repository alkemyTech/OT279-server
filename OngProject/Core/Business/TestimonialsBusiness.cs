using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.TestimonialDTO;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class TestimonialsBusiness : ITestimonialsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public TestimonialsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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

        public async Task<Testimonials> Insert(TestimonialInsertDto testimonialsDto)
        {
            var testimonial = new Testimonials()
            {
                Name = testimonialsDto.Name,
                //Image = testimonialsDto.Image,
                Content = testimonialsDto.Content,
            };

            await _unitOfWork.TestiomonialsRepository.Insert(testimonial);
            _unitOfWork.SaveChanges();

            return testimonial;
        }

        public Task<Testimonials> Update(int id, Testimonials testimonials)
        {
            throw new System.NotImplementedException();
        }
    }
}
