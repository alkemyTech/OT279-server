using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface INewsBusiness
    {
        Task<List<News>> GetAllNews();
        Task<News> GetNewsById(int id);
        Task<IEnumerable<CommentGetDto>> GetNewsByIdComments(int id);
        Task<News> CreateNews(News news);
        public Task<bool> RemoveNews(int id);
        public Task<News> UpdateNews(int id, News news);
    }
}
