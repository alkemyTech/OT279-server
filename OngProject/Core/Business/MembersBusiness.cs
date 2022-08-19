using OngProject.Core.Interfaces;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class MembersBusiness : IMembersBusiness
    {
        private readonly IMembersRepository _membersRepository;
        public MembersBusiness(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        public IEnumerable<Members> GetAll()
        {
            throw new NotImplementedException();
        }

        public Members GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Members member)
        {
            throw new NotImplementedException();
        }
        public void Update(Members updatedMember)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
