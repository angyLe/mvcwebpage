using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Context : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<ImageLink> ImageLinks { get; set; }

        public Context() : base("DefaultConnection")
        {
        }
    }
}