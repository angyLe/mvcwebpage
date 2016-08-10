using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class siteOneElemente
    {
        [Key]
        public int siteoneelemId {get; set; }

        // 1- M between siteOneElement - imageLink
        public virtual ICollection<imageLink> imgLink { get; set; }

        
    }
}
