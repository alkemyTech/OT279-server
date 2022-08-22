using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly OngDbContext _context;
        public MembersRepository(OngDbContext context)
        {
            _context = context;
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
