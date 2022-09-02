using Microsoft.AspNetCore.Http;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISlidesBusiness
    {
        public Task<IEnumerable<SlidesOrderImageDTO>> GetAllSlides();
        public Task<SlideDTO> GetSlideById(int id);
        public Task<SlideDTO> CreateSlide(SlideDTO slide);
        public Task<bool> RemoveSlide(int id);
        public Task<Slides> UpdateSlide(int id, Slides slideDTO);

    }
}
