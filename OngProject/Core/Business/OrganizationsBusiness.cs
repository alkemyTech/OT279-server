using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class OrganizationsBusiness : IOrganizationsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> DeleteOrganization(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Organization>> GetAllOrganization()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Organization> GetByIdOrganization(int id)
        {
            return await _unitOfWork.OrganizationRepository.GetById(id);   
        }

        public Task<Organization> InsertOrganization(Organization organization)
        {
            throw new System.NotImplementedException();
        }

        public Task<Organization> UpdateOrganization(int id, Organization organization)
        {
            throw new System.NotImplementedException();
        }
    }
}
