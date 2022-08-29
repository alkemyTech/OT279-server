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
        public MembersBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<MembersDTO>> GetAllMembers()
        {
            List<Members> membersList;
            List<MembersDTO> membersDTOList = new List<MembersDTO>();

            membersList = (List<Members>) await _unitOfWork.MembersRepository.GetAll();

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
