using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    public class Testimony : Entity
    {
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }


        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Image { get; set; }


        [MaxLength(65535)]
        [Column(TypeName = "varchar")]
        public string Content { get; set; }
    }
}
