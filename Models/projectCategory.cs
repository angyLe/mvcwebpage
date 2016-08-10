using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class projectCategory // catergory of the project
    {

        public int projectCategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public projectCategory()
        {
            Projects = new List <Project>();
        }

    }
}