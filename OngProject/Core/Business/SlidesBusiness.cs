using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlidesBusiness : ISlidesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public SlidesBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Slides> CreateSlide(Slides slide)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Slides>> GetAllSlides()
        {
            return _unitOfWork.SlidesRepository.GetAll();
        }

        public Task<Slides> GetSlideById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveSlide(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Slides> UpdateSlide(int id, Slides slideDTO)
        {
            throw new NotImplementedException();
        }
    }
}
