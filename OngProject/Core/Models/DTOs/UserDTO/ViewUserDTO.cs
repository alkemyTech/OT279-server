using OngProject.Entities;

namespace OngProject.Core.Models.DTOs.UserDTO
{
    public class ViewUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Role Role { get; set; }


        public ViewUserDTO(User u)
        {
            FirstName = u.FirstName;
            LastName = u.LastName;
            Email = u.Email;
            Photo = u.Photo;
            Role = u.Role;
        }
    }
}
