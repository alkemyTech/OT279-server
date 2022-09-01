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
            _unitOfWork = unitOfWork;
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
        public async Task<Members> GetMemberById(int id)
        {
            var members = await _unitOfWork.MembersRepository.GetById(id);

            return members;
        }
        public Task<Members> CreateMember()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteMember(Members members)
        {
            bool flag = false;
            try
               {
                    await _unitOfWork.MembersRepository.Delete(members);
                    _unitOfWork.SaveChanges();
                    flag = true;
               }
            catch (Exception ex)
            {
                    throw ex;
            }

            return flag;
        }

        public Task<Members> UpdateMember()
        {
            throw new NotImplementedException();
        }
    }
}
