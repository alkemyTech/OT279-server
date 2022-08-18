using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class Role
    {
        // Id is not defined yet.

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        // UpdatedAt - Timestamp
        // It is allowed to be null
        public DateTime? UpdatedAt { get; set; }
    }
}
