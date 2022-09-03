using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Mapper;
using System;

namespace OngProject.Core.Business
{
    public class NewsBusiness : INewsBusiness
    {
        private readonly IAmazonS3Client _amazonS3Client;
        private readonly IUnitOfWork _unitOfWork;
        public NewsBusiness(IUnitOfWork unitOfWork, IAmazonS3Client amazonS3Client)
        {
            _unitOfWork = unitOfWork;
            _amazonS3Client = amazonS3Client;
        }
        public async Task<News> CreateNews(InserNewDto newDto)
        {
            string imgUrl = await _amazonS3Client.UploadObject(newDto.Image);
           
            News news = new News
            {
                Name = newDto.Name,
                Content = newDto.Content,
                Image = imgUrl,
                CategoryId = newDto.CategoryId
            };
              await _unitOfWork.NewsRepository.Insert(news);
             _unitOfWork.SaveChanges();

            return news;

        }

        public Task<List<News>> GetAllNews()
        {
            throw new System.NotImplementedException();
        }

        public Task<News> GetNewsById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CommentGetDto>> GetNewsByIdComments(int id)
        {
            var comments = await _unitOfWork.CommentsRepository.GetAll();
            var commentForNews = comments.Where(x=>x.NewsId==id);
            
            List<CommentGetDto> listComment = new();
            foreach (var comment in commentForNews)
            {
                var commentDto = CommentsMapper.CommentsToCommentsDTO(comment);
                listComment.Add(commentDto);
            }
            return listComment;
        }

        public async Task<bool> RemoveNews(int id)
        {
            var news = await _unitOfWork.NewsRepository.GetById(id);
            if(news != null)
            {
                try
                {
                    await _unitOfWork.NewsRepository.Delete(news);
                    _unitOfWork.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }

        public Task<News> UpdateNews(int id, News news)
        {
            throw new System.NotImplementedException();
        }
    }
}
