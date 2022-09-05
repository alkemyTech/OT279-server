using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models.DTOs.OrganizationDTO;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            var listOrganizations = await _unitOfWork.OrganizationRepository.GetAll();
            var listSlides = await _unitOfWork.SlidesRepository.GetAll();

            var orderedListSlides = listSlides.OrderBy(s => s.Order);

            List<GetOrganizationDto> listDto = new List<GetOrganizationDto>();
      
            foreach (var organization in listOrganizations)
            {
                var organizacionDto = new GetOrganizationDto(organization);
                foreach (var slide in orderedListSlides)
                {
                    if (slide.OrganizationId == organization.Id)
                    {
                        organizacionDto._listSlides.Add(new SlideDTO(slide));
                    }
                }
                listDto.Add(organizacionDto);
            }
            return listDto;
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
