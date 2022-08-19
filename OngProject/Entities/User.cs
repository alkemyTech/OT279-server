using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User 
    {
        /*
            TODO: Heredar de clase base Entity para obtener ID, softDeleted y timestamp
         */

        private string _firstname;
        private string _lastname;
        private string _email;
        private string _password;
        private string _photo;
        private int _roleId;

        [Required, MaxLength(255)]
        [Display(Name = "First_Name")]
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        [Required, MaxLength(255)]
        [Display(Name = "Last_Name")]
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        [Required, MaxLength(320)]
        [Display(Name = "Email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [Required, MaxLength(20)]
        [Display(Name = "Password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [MaxLength(255)]
        [Display(Name = "Photo")]
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        [ForeignKey("Role")]
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        /*
        TODO: agregar atributo "Role".
        
        private Role _role; 
        
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        */
        private User() { }

        public User(string firstname, string lastname, string email, string password, string photo, int roleId)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            Photo = photo;
            RoleId = roleId;
        }
    }
}
