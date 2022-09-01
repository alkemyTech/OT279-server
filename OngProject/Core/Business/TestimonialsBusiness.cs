using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
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


        public async Task<bool> DeleteTestimonials(Testimonials testimonials)
        {
            bool flag = false;
            try
            {
                await _unitOfWork.TestimonialsRepository.Delete(testimonials);
                _unitOfWork.SaveChanges();
                flag = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        public Task<System.Collections.Generic.List<Testimonials>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Testimonials> GetById(int id)
        {
            var testimonials = await _unitOfWork.TestimonialsRepository.GetById(id);

            return testimonials;
        }

        public Task<Testimonials> Insert(Testimonials testimonials)
        {
            throw new System.NotImplementedException();
        }

        public Task<Testimonials> Update(int id, Testimonials testimonials)
        {
            throw new System.NotImplementedException();
        }
    }
}
