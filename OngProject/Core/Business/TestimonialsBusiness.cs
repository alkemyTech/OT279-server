using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.TestimonialDTO;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class TestimonialsBusiness : ITestimonialsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAmazonS3Client _amazonS3Client;
        public TestimonialsBusiness(IUnitOfWork unitOfWork, IAmazonS3Client amazonS3Client)
        {
            _unitOfWork = unitOfWork;
            _amazonS3Client = amazonS3Client;
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
            var imageUrl = string.Empty;

            try
            {
                imageUrl = await _amazonS3Client.UploadObject(testimonialsDto.Image);
            }
            catch (System.Exception)
            {
                throw new Exception("Cannot save the image on Amazon S3");
            }

            var testimonial = new Testimonials()
            {
                Name = testimonialsDto.Name,
                Image = imageUrl,
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
