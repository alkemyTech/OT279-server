using AutoMapper;
using OngProject.Core.Models.DTOs.UserDTO;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<User, UserRegisterDTO>().ReverseMap();
        }
    }
}
