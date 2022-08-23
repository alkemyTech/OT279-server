using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.DataAccess
{
    public class OngDbContext : DbContext
    {
        public OngDbContext(DbContextOptions<OngDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }

        public DbSet<Activities> Activities { get; set; }
        public DbSet<Members> Members { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Slides> Slides { get; set; }
    }
}
