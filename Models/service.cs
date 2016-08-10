using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
   [Table("Services")]
    public class Serv : siteOneElemente
    {

        //public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }


        // 1 - 0 siteOneElement - service
        // public int siteOneElemId { get; set; }
        // public virtual siteOneElement siteOneElem { get; set; }
    }
}