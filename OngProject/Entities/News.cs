using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class News : Entity
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [MaxLength(65535)]
        public string Content { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(255)]
        public string Image { get; set; }

        // Falta agregar Entidad Categoria
        //public int CategoriaId { get; set; }
        //public Category Category { get; set; }
    }
}
