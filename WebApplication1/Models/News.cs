using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    [Table("News")]
    public class News 
    {
        public int NewsId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [DataType(DataType.MultilineText)]
        public string Annonce { get; set; }

        [Required]
        public int ImageLinkId { get; set; }
        [ForeignKey("ImageLinkId")]
        public virtual ImageLink ImageLink { get; set; }

    }
}