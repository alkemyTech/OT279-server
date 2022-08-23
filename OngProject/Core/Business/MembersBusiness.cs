using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class MembersBusiness : IMembersBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public MembersBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Members>> GetAllMembers()
        {
            throw new NotImplementedException();
        }
        public Task<Members> GetMemberById()
        {
            throw new NotImplementedException();
        }
        public Task<Members> CreateMember()
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteMember()
        {
            throw new NotImplementedException();
        }
        public Task<Members> UpdateMember()
        {
            throw new NotImplementedException();
        }
    }
}
