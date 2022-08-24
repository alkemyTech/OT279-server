using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class NewsBusiness : INewsBusiness
    {
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
