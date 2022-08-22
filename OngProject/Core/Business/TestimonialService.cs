using OngProject.Core.Interfaces;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TestimonialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Delete(int id)
        {
            var exist = await _unitOfWork.TestimonialRepository.GetById(id);
            if (exist == null)
                throw new Exception("Role not found.");
            _unitOfWork.TestimonialRepository.Delete(exist);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Testimonials>> GetAll()
        {
           
            return await _unitOfWork.TestimonialRepository.GetAll();
        }

        public async Task<Testimonials> GetById(int id)
        {
             return await _unitOfWork.TestimonialRepository.GetById(id);
        }

        public async Task Insert(Testimonials entity)
        {
           await _unitOfWork.TestimonialRepository.Insert(entity);
        }

        public async Task Update(int id, Testimonials entity)
        {
            await _unitOfWork.TestimonialRepository.Update(id, entity);
        }
    }
}
