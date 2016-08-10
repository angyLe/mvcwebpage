using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    public class imageLink
    {
        public int ImageLinkId { get; set; }

        public string Link { get; set; }

        // 1 - M between imageLink - siteOneElement
        public int siteOneElemId { get; set; }
        public virtual siteOneElemente siteElement { get; set; }


    }

}