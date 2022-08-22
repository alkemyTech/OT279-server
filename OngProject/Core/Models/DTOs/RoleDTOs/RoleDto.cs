using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs.RoleDTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
