using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class MembersBusiness : IMembersBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Members> _repository;
        public MembersBusiness(IUnitOfWork unitOfWork, IRepository<Members> repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public async Task<List<MembersDTO>> GetAllMembers()
        {
            List<Members> membersList;
            List<MembersDTO> membersDTOList = new List<MembersDTO>();

            membersList = (List<Members>) await _repository.GetAll();

            foreach (Members m in membersList)
            {
                membersDTOList.Add(MembersMapper.MembersToMembersDTO(m));
            }

            return membersDTOList;
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
