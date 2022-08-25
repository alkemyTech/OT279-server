using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using OngProject.Repositories.Interfaces;

namespace OngProject.Core.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUnitOfWork _unitOfWork;

        public UsersBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _unitOfWork.UserRepository.GetAll();
            List<User> _listAux = new List<User>();
            foreach (var user in result)
            {
                _listAux.Add(user);
            }
            return _listAux; 
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
