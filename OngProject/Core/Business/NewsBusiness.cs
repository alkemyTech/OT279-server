using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Mapper;
using System;
using OngProject.Core.Models.DTOs.NewsDTO;

namespace OngProject.Core.Business
{
    public class NewsBusiness : INewsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<News> CreateNews(News news)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<News>> GetAllNews()
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetNewsDto> GetNewsById(int id)
        {
           var newsById = await _unitOfWork.NewsRepository.GetById(id);
            var newsDto = NewsMapper.NewsToGetNewsDTO(newsById);
            return newsDto;
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
