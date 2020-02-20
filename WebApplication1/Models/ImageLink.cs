using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ImageLink
    {
        [Key]
        public int ImageLinkId { get; set; }

        [Required]
        public string Link { get; set; }
    }

}