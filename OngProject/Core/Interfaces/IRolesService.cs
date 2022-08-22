using OngProject.Core.Models.DTOs.RoleDTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RoleDto>> GetAll();
        Task<RoleDto> GetById(int id);
        Task Insert(RoleInsertDto entity);
        Task Delete(int id);
        Task Update(int id, RoleUpdateDto entity);
    }
}
