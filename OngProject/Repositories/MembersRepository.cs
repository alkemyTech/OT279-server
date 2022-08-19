using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections;

namespace OngProject.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly OngDbContext _context;

        public MembersRepository(OngDbContext context)
        {
            _context= context;
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
        public void Update(Member updatedMember)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
