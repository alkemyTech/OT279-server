using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IMembersRepository
    {
        public Task<List<Members>> GetAllMembers();
        public Task<Members> GetMemberById();
        public Task<Members> CreateMember();
        public Task<bool> DeleteMember();
        public Task<Members> UpdateMember();
    }
}
