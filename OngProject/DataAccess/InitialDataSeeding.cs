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
                   new Category { Id = 1, Name = "category1", Image = "url img", Description = "description category1", IsDeleted = false, LastModified = DateTime.UtcNow },
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

            modelBuilder.Entity<Role>()
                .HasData(
                    new Role { Id = 1, Name = "Admin", Description = "System Administrator", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Role { Id = 2, Name = "User", Description = "System User", IsDeleted = false, LastModified = DateTime.UtcNow }
                );


            modelBuilder.Entity<Members>()
                .HasData(
                    new Members { Id = 1, Name = "Members01", Image = "url_image_members01", Description = "Description members01", FacebookUrl = "url_facebook_members01", InstagramUrl = "url_instagram_members01", LinkedinUrl = "url_linkedIn_members01", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Members { Id = 2, Name = "Members02", Image = "url_image_members02", Description = "Description members02", FacebookUrl = "url_facebook_members02", InstagramUrl = "url_instagram_members02", LinkedinUrl = "url_linkedIn_members02", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Members { Id = 3, Name = "Members03", Image = "url_image_members03", Description = "Description members03", FacebookUrl = "url_facebook_members03", InstagramUrl = "url_instagram_members03", LinkedinUrl = "url_linkedIn_members03", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Members { Id = 4, Name = "Members04", Image = "url_image_members04", Description = "Description members04", FacebookUrl = "url_facebook_members04", InstagramUrl = "url_instagram_members04", LinkedinUrl = "url_linkedIn_members04", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Members { Id = 5, Name = "Members05", Image = "url_image_members05", Description = "Description members05", FacebookUrl = "url_facebook_members05", InstagramUrl = "url_instagram_members05", LinkedinUrl = "url_linkedIn_members05", IsDeleted = false, LastModified = DateTime.UtcNow }
              );

            modelBuilder.Entity<Activities>()
                .HasData(
                    new Activities { Id = 1, Name = "Activities 01", Image = "url_img", Content = "this is a content - activities 01", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Activities { Id = 2, Name = "Activities 02", Image = "url_img", Content = "this is a content - activities 02", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Activities { Id = 3, Name = "Activities 03", Image = "url_img", Content = "this is a content - activities 03", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Activities { Id = 4, Name = "Activities 04", Image = "url_img", Content = "this is a content - activities 04", IsDeleted = false, LastModified = DateTime.UtcNow }

                );

            modelBuilder.Entity<Testimonials>()
                .HasData(
                    new Testimonials { Id = 1, Name = "Testimonials01", Image = "url_image_testimonials01", Content = "Content testimonials01", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Testimonials { Id = 2, Name = "Testimonials02", Image = "url_image_testimonials02", Content = "Content testimonials02", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Testimonials { Id = 3, Name = "Testimonials03", Image = "url_image_testimonials03", Content = "Content testimonials03", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Testimonials { Id = 4, Name = "Testimonials04", Image = "url_image_testimonials04", Content = "Content testimonials04", IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Testimonials { Id = 5, Name = "Testimonials05", Image = "url_image_testimonials05", Content = "Content testimonials05", IsDeleted = false, LastModified = DateTime.UtcNow }
                );

            modelBuilder.Entity<Contacts>()
                .HasData(
                    new Contacts { Id = 1, Name = "ContactName01", Email = "contact01@mail.com", Message = "message01", Phone = 11111111, IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Contacts { Id = 2, Name = "ContactName02", Email = "contact02@mail.com", Message = "message02", Phone = 22222222, IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Contacts { Id = 3, Name = "ContactName03", Email = "contact03@mail.com", Message = "message03", Phone = 33333333, IsDeleted = false, LastModified = DateTime.UtcNow },
                    new Contacts { Id = 4, Name = "ContactName04", Email = "contact04@mail.com", Message = "message04", Phone = 44444444, IsDeleted = false, LastModified = DateTime.UtcNow }
                );
        }
    }
}