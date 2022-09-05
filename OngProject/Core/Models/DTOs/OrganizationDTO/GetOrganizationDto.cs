using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Core.Models.DTOs.OrganizationDTO
{
    public class GetOrganizationDto
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public int? Phone { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}
