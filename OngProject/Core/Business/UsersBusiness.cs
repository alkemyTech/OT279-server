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

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using System.Linq;
using AutoMapper;
using OngProject.Core.Mapper;


namespace OngProject.Core.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly OngDbContext _context;
        private readonly IAuthBusiness _authBusiness;

        public UsersBusiness(IUnitOfWork unitOfWork, OngDbContext context, IAuthBusiness authBusiness) //no se deberia utilizar OngDbContext
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _authBusiness = authBusiness;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if(user != null)
            {
                try
                {
                    await _unitOfWork.UserRepository.Delete(user);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
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

        public async Task<string> Insert(UserRegisterDTO userDTO)
        {
            var mapper = new EntityMapper();
            var user = mapper.FromRegisterDtoToUser(userDTO);

            var userExists = await this.GetByEmail(user.Email);
            if (userExists == null)
            {
                user.Password = ApiHelper.GetSHA256(user.Password);
                user.Role = await _unitOfWork.RoleRepository.GetById(2);
                user.RoleId = user.Role.Id;

                await _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.SaveChanges();

                var userDB = await this.GetByEmail(user.Email);
                return _authBusiness.GetToken(userDB);
            }
            return "";
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
               .Include(x => x.Role)
               .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> ValidateUser(User user, string password)
        {
            string encriptedPassword = ApiHelper.GetSHA256(password);
            if (user.Password != encriptedPassword)
            {
                return null;
            }
            return user;
        }

        public Task<User> Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
