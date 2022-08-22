using OngProject.Core.Models.DTOs.RoleDTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<object>> GetAll();
        Task<RoleDto> GetById();
        Task Insert();
        Task Delete();
        Task Update();
    }
}
