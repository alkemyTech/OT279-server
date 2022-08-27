using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class ContactsDTO
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
