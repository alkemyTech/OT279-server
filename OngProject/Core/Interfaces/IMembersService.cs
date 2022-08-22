using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMembersService
    {
        public Task<List<Members>> GetAllMembers();
        public Task<Members> GetMemberById(int Id);
        public Task<Members> CreateMember(MemberDTO member);
        public Task<bool> DeleteMember(int Id);
        public Task<Members> UpdateMember(int Id, MemberDTO memberDTO);
    }
}
