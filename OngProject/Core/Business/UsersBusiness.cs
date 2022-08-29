using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using OngProject.Repositories.Interfaces;
using OngProject.Core.Models.DTOs.UserDTO;
using OngProject.Core.Helper;
using Microsoft.AspNetCore.Identity;
using OngProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using OngProject.Core.Mapper;

namespace OngProject.Core.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly OngDbContext _context;
        private readonly IMapper _mapper;
        public UsersBusiness(IUnitOfWork unitOfWork, OngDbContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ViewUserDTO>> GetAll()
        {
            var result = await _unitOfWork.UserRepository.GetAll();
            List<ViewUserDTO> _listAux = new List<ViewUserDTO>();
            foreach (var user in result)
            {
                _listAux.Add(new ViewUserDTO(user));
            }
            return _listAux; 
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRegisterDTO> Insert(UserRegisterDTO userDTO)
        {
            var mapper = new EntityMapper();
            var user = mapper.FromRegisterDtoToUser(userDTO);

            var userExists = ExistsUserEmail(user.Email);
            if (!userExists)
            {
                user.Password = ApiHelper.GetSHA256(user.Password);
                user.Role = await _unitOfWork.RoleRepository.GetById(2);

                await _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.SaveChanges();

                var dto = mapper.FromUserToUserDto(user);
                return dto;
            }
            return null;
        }

        public bool ExistsUserEmail(string email)
        {
            return  _context.Set<User>().Any(x => x.Email == email);
        }

        public Task<User> Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
