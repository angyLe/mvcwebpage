using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ImageLinkId { get; set; }
        [ForeignKey("ImageLinkId")]
        public ImageLink ImageLink { get; set; }

        public ICollection <ProjectCategory> ProjectCategories { get; set; }

        public Project()
        {
            ProjectCategories = new List<ProjectCategory>();
        }
    }
}