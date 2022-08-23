using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class OrganizationsService : IOrganizationsService
    {
        private readonly UnitOfWork _unitOfWork;

        public OrganizationsService(UnitOfWork unitOfWork)
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

        public Task<Organization> GetByIdOrganization(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Organization> InsertOrganization(OrganizationDTO organization)
        {
            throw new System.NotImplementedException();
        }

        public Task<Organization> UpdateOrganization(int id, OrganizationDTO organization)
        {
            throw new System.NotImplementedException();
        }
    }
}
