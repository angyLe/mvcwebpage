using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectCategory
    {
        public int ProjectCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ProjectCategory()
        {
            Projects = new List<Project>();
        }

    }
}