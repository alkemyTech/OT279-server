using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.RoleDTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class RolesService : IRolesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Delete(int id)
        {
            var existing = await _unitOfWork._roleRepository.GetById(id);

            if (existing == null)
                throw new Exception("Role not found.");

            // soft delete
            existing.IsDeleted = true;

            _unitOfWork._roleRepository.Update(existing);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            // Mapper library must work at this point in order to return valid type ( RoleDto )
            throw new System.NotImplementedException();
        }

        public Task<RoleDto> GetById(int id)
        {
            // Mapper library must work at this point in order to return valid type ( RoleDto )
            throw new System.NotImplementedException();
        }

        public async Task Insert(RoleInsertDto entity)
        {
            var toInsert = new Role
            {
                Name = entity.Name,
                Description = entity.Description,
            };

            await _unitOfWork._roleRepository.Insert(toInsert); 
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, RoleUpdateDto entity)
        {
            var existing = await _unitOfWork._roleRepository.GetById(id);

            if (existing == null)
                throw new Exception("Role not found.");

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.LastModified = DateTime.UtcNow;

            _unitOfWork._roleRepository.Update(existing);
            await _unitOfWork.Complete();
        }
    }
}
