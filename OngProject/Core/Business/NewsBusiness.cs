using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Mapper;

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

        public Task<bool> RemoveNews(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<News> UpdateNews(int id, News news)
        {
            throw new System.NotImplementedException();
        }
    }
}
