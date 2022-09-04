using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models.DTOs.UserDTO;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
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

        public async Task<bool> DeleteComments(Comments comments)
        {
            try
            {
                await _unitOfWork.CommentsRepository.Delete(comments);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CommentGetDto>> GetAll()
        {
            var comments = await _unitOfWork.CommentsRepository.GetAll();
            var commentOrd = comments.OrderByDescending(x => x.LastModified);
            IEnumerable<Comments> ordenby = commentOrd;

            List<CommentGetDto> listComment = new();
            
            foreach (var comment in ordenby)
            {
                CommentGetDto commentDto = new()
                {
                    Body = comment.Body
                };
                listComment.Add(commentDto);
            }

            return listComment;
        }

        public async Task<Comments> GetById(int id)
        {
            var comments = await _unitOfWork.CommentsRepository.GetById(id);

            return comments;
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
