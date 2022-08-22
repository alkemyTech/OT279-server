using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMembersBusiness
    {
        public Task<List<Members>> GetAllMembers();
        public Task<Members> GetMemberById();
        public Task<Members> CreateMember();
        public Task<bool> DeleteMember();
        public Task<Members> UpdateMember();
    }
}
