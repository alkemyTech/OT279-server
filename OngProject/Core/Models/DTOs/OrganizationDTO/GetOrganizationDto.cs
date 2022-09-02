using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Core.Models.DTOs.OrganizationDTO
{
    public class GetOrganizationDto
    {
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }


        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Image { get; set; }



        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }


        [MaxLength(20)]
        public int? Phone { get; set; }
    }
}
