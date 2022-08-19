using System;

namespace OngProject.Core.Models
{
    public class Entity
    {
        public int Id { get; set; }

        // Timestamps
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        // SoftDelete field
        public bool IsDeleted { get; set; } =  false;
    }
}
