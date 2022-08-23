using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISlidesService
    {
        public Task<List<Slides>> GetAllSlides();
        public Task<Slides> GetSlideById(int id);
        public Task<Slides> CreateSlide(Slides slide);
        public Task<bool> RemoveSlide(int id);
        public Task<Slides> UpdateSlide(int id, Slides slideDTO);
    }
}
