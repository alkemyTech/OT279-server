using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlidesService : ISlidesService
    {
        public Task<Slides> CreateSlide(Slides slide)
        {
            throw new NotImplementedException();
        }

        public Task<List<Slides>> GetAllSlides()
        {
            throw new NotImplementedException();
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
