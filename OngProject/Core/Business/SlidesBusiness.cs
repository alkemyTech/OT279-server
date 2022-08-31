using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlidesBusiness : ISlidesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAmazonS3Client _amazonS3Client;
        private readonly IOrganizationsBusiness _organizationBusiness;
        private readonly OngDbContext _context;
        public SlidesBusiness(IUnitOfWork unitOfWork, IAmazonS3Client amazonS3Client, OngDbContext context, IOrganizationsBusiness organizationBusiness)
        {
            _unitOfWork = unitOfWork;
            _amazonS3Client = amazonS3Client;
            _context = context;
            _organizationBusiness = organizationBusiness;
        }

        public async Task CreateSlide(SlideDTO slideDTO)
        {
            var fileName = Guid.NewGuid().ToString();
            try
            {
                MemoryStream fileStream = new MemoryStream(Convert.FromBase64String(slideDTO.ImageBase64.Split(",", 2)[1]));        
                var url = await _amazonS3Client.UploadObject(fileStream);

                if (slideDTO.Order == null || slideDTO.Order == 0)
                {
                    var lastSlide =  await _context.Slides.OrderByDescending(s=> s.LastModified).FirstOrDefaultAsync();
                    slideDTO.Order = lastSlide.Order;
                }

                var organization = await _organizationBusiness.GetByIdOrganization(slideDTO.OrganizationId);
                
                if (organization == null) {
                    throw new Exception("Ingreso un 'ID' de una organizacion inexistente");
                }

                Slides slide = new Slides
                {
                    Text = slideDTO.Text,
                    OrganizationId = slideDTO.OrganizationId,
                    ImageUrl = url,
                    Order = slideDTO.Order.Value
                };

                await _unitOfWork.SlidesRepository.Insert(slide);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                await _amazonS3Client.DeleteObject(fileName);
            }
        }

        public async Task<IEnumerable<SlidesOrderImageDTO>> GetAllSlides()
        {
            var slides = await _unitOfWork.SlidesRepository.GetAll();
            var slidesOrderImage = new List<SlidesOrderImageDTO>();
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

        public async Task<SlideDTO> GetSlideById(int id)
        {
            var slide = await _unitOfWork.SlidesRepository.GetById(id);
            if (slide == null)
            {
                return null;
            }
            return new SlideDTO(slide);
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
