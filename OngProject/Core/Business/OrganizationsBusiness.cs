using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models.DTOs.OrganizationDTO;
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

        public async Task<List<GetOrganizationDto>> GetAllOrganization()
        {
             var organization = await _unitOfWork.OrganizationRepository.GetAll();
            List<GetOrganizationDto> listDto = new ();
            foreach (var item in organization)
            {
                GetOrganizationDto dto = OrganizationMapper.OrganizationToGetOrganizationDTO(item);
                listDto.Add(dto);
            }
            return listDto;
        }

        public Task<Organization> GetByIdOrganization(int id)
        {
            throw new System.NotImplementedException();
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
