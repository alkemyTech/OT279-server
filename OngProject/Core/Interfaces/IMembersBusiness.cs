using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMembersBusiness
    {
        public Task<List<MembersDTO>> GetAllMembers();
        public Task<Members> GetMemberById(int id);
        public Task<Members> CreateMember();
        public Task<bool> DeleteMember(Members members);
        public Task<Members> UpdateMember();
    }
}
