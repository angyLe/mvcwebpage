using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Context: DbContext
    {
        public DbSet <news> news { get; set; }
        public DbSet <Serv> Services { get; set; }
        public DbSet <siteOneElemente> oneElements { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<projectCategory> projectCats {get; set;}
        public DbSet <imageLink> imageLinks { get; set; }



        public Context() : base("DefaultConnection")
        {
        }

        /*Дальше идет самое интересное. В создаваемой базе данных все данные о
        студентах будут храниться в таблице Students, а данные о университетских курсах - 
        в таблице Courses. Но эти таблица должны быть как-то связаны связью многие-ко-многим.
        И эту связь обеспечит еще одна таблица, которая будет называться CourseStudent
        */
   
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<siteOneElement>().ToTable("siteOneElements");
            //modelBuilder.Entity<news>().ToTable("news");
            //modelBuilder.Entity<Service>().ToTable("Services");

            /*
            modelBuilder.Entity<Project>().HasMany(c => c.projectCats)
                    .WithMany(s => s.Projects)
                    .Map(t => t.MapLeftKey("ProjectId")
                    .MapRightKey("ProjectCatId")
                    .ToTable("ProjectCatigorys")); */
        //}
       

    }
}