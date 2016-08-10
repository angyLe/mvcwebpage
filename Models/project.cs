using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Project
    {
       
        public int ProjectId { get; set; }
     
        public string ProjectDescription { get; set; }
        
        public string Customer { get; set; }
       
        public int Price { get; set; }
       
        public DateTime Date { get; set; }

        public string Image { get; set; }

        public virtual ICollection <projectCategory> projectCats { get; set; }

        public Project()
        {
            projectCats = new List<projectCategory>();
        }
    }
}