using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public class CommentsMapper
    {
        public static CommentGetDto CommentsToCommentsDTO(Comments comments)
        {
            CommentGetDto commentGetDto = new ()
            {
                Body = comments.Body,
             
            };
            return commentGetDto;
        }
    }
}
