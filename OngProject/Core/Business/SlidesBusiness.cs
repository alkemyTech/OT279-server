using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
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

        public async Task<IEnumerable<SlidesOrderImageDTO>> GetAllSlides()
        {
            var slides = await _unitOfWork.SlidesRepository.GetAll();

            var slidesOrderImage = new List<SlidesOrderImageDTO>() { };

            foreach (var slide in slides)
            {
                var slideDTO = new SlidesOrderImageDTO()
                {
                    ImageUrl = slide.ImageUrl,
                    Order = slide.Order
                };

                slidesOrderImage.Add(slideDTO);
            }
            return slidesOrderImage;
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
