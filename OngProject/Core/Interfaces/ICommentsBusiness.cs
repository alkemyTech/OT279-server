using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICommentsBusiness
    {
        Task<IEnumerable<CommentGetDto>> GetAll();
        Task<Comments> GetById(int id);
        Task<Comments> Insert(Comments Comments);
        Task<bool> Delete(int id);
        Task<Comments> Update(int id, Comments Comments);
    }
}
