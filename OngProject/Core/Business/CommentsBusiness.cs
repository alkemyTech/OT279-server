using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CommentsBusiness : ICommentsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Comments>> GetAll()
        {
            var comments = await _unitOfWork.CommentsRepository.GetAll();
            var commentOrd = comments.OrderByDescending(x => x.LastModified);
            IEnumerable<Comments> ordenby = commentOrd;
            
            return ordenby;
        }

        public Task<Comments> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Comments> Insert(Comments Comments)
        {
            throw new System.NotImplementedException();
        }

        public Task<Comments> Update(int id, Comments Comments)
        {
            throw new System.NotImplementedException();
        }
    }
}
