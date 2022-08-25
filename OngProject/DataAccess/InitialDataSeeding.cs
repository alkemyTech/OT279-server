using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class InitialDataSeeding
    {
        public static void Seeding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                   new Category { Id = 1, Name = "category1", Image = "url img", Description = "description category1", IsDeleted = false, LastModified = DateTime.UtcNow},
                   new Category { Id = 2, Name = "category2", Image = "url img", Description = "description category2", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Category { Id = 3, Name = "category3", Image = "url img", Description = "description category3", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Category { Id = 4, Name = "category4", Image = "url img", Description = "description category4", IsDeleted = false, LastModified = DateTime.UtcNow },
                   new Category { Id = 5, Name = "category5", Image = "url img", Description = "description category5", IsDeleted = false, LastModified = DateTime.UtcNow }
                );
        }
    }
}
