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

            modelBuilder.Entity<News>()
                .HasData(
                    new News { Id = 1, Name = "News01", Image = "url_img", Content = "this is a content - news 01", CategoryId = 2, IsDeleted = false, LastModified = DateTime.UtcNow },
                    new News { Id = 2, Name = "News02", Image = "url_img", Content = "this is a content - news 02", CategoryId = 3, IsDeleted = false, LastModified = DateTime.UtcNow },
                    new News { Id = 3, Name = "News03", Image = "url_img", Content = "this is a content - news 03", CategoryId = 3, IsDeleted = false, LastModified = DateTime.UtcNow },
                    new News { Id = 4, Name = "News04", Image = "url_img", Content = "this is a content - news 04", CategoryId = 1, IsDeleted = false, LastModified = DateTime.UtcNow }
                );

            modelBuilder.Entity<Members>()
                .HasData(
                    new Members { Id = 1, Name = "Name01", Image = "url_image_name01", Description = "Description Name01", FacebookUrl = "url_facebook_name01", InstagramUrl = "url_instagram_name01", LinkedinUrl = "url_linkedIn_name01", IsDeleted = false, LastModified = DateTime.UtcNow},
                    new Members { Id = 2, Name = "Name02", Image = "url_image_name02", Description = "Description Name02", FacebookUrl = "url_facebook_name02", InstagramUrl = "url_instagram_name02", LinkedinUrl = "url_linkedIn_name02", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Members { Id = 3, Name = "Name03", Image = "url_image_name03", Description = "Description Name03", FacebookUrl = "url_facebook_name03", InstagramUrl = "url_instagram_name03", LinkedinUrl = "url_linkedIn_name03", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Members { Id = 4, Name = "Name04", Image = "url_image_name04", Description = "Description Name04", FacebookUrl = "url_facebook_name04", InstagramUrl = "url_instagram_name04", LinkedinUrl = "url_linkedIn_name04", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Members { Id = 5, Name = "Name05", Image = "url_image_name05", Description = "Description Name05", FacebookUrl = "url_facebook_name05", InstagramUrl = "url_instagram_name05", LinkedinUrl = "url_linkedIn_name05", IsDeleted = false, LastModified = DateTime.UtcNow }
                );
        }
    }
}