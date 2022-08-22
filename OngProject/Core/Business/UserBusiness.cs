using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace OngProject.Core.Business
{
    public class UserBusiness : IUserService
    {
        public Task<User> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
