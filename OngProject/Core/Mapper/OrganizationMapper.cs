using OngProject.Core.Models.DTOs.OrganizationDTO;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public class OrganizationMapper
    {
        public static GetOrganizationDto OrganizationToGetOrganizationDTO(Organization organization)
        {
            GetOrganizationDto getOrganizationDto = new()
            {
                Name = organization.Name,
                Image = organization.Image,
                Phone = organization.Phone,
                Address = organization.Address

            };
            return getOrganizationDto;
        }
    }
}
