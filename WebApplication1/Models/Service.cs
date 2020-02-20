using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Services")]
    public class Service 
    {
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public double Price { get; set; }

        [Required]
        public int ImageLinkId { get; set; }
        [ForeignKey("ImageLinkId")]
        public ImageLink ImageLink { get; set; }
      
    }
}