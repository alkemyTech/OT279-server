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


namespace OngProject.Core.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly OngDbContext _context;
        public UsersBusiness(IUnitOfWork unitOfWork, OngDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
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

        public async Task<User> Insert(UserRegisterDTO userDTO)
        {
            User user = await GetByEmail(userDTO.Email);
            if (user == null)
            {
                string encriptedPassword = ApiHelper.GetSHA256(user.Password);
                userDTO.Password = encriptedPassword;
                await _unitOfWork.UserRepository.Insert(user);
                return user;
            }
            return null;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
