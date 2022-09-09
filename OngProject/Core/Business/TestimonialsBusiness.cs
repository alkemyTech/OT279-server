using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
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


        public async Task<bool> DeleteTestimonials(Testimonials testimonials)
        {
            
            try
            {
                await _unitOfWork.TestimonialsRepository.Delete(testimonials);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                throw new Exception("Cannot delete Testimonial");
            }

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

            await _unitOfWork.TestimonialsRepository.Insert(testimonial);
            _unitOfWork.SaveChanges();

            return testimonial;
        }

        public async Task<Testimonials> UpdateTestimonials(int id, TestimonialUpdateDto testimonialsToUpdate)
        {
            
            var currentTestimonial = await GetById(id);
            currentTestimonial.Image = testimonialsToUpdate == null ? currentTestimonial.Image : await _amazonS3Client.UploadObject(testimonialsToUpdate.Image);
            currentTestimonial.Content = testimonialsToUpdate.Content;
            currentTestimonial.Name = testimonialsToUpdate.Name;
            currentTestimonial.LastModified = DateTime.UtcNow;
            _unitOfWork.TestimonialsRepository.Update(currentTestimonial);
            _unitOfWork.SaveChanges();

            return currentTestimonial;
        }
    }
}
