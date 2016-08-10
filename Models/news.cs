using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    [Table("News")]
    public class news: siteOneElemente
    {

        //public int newsId { get; set; }
        [DataType(DataType.MultilineText)]

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]

        public string Text { get; set; }

        [DataType(DataType.MultilineText)]
        public string Anonce { get; set; }

        // 1 - 0 siteOneElement - news
       // public int siteOneElemId { get; set; }
       // public virtual siteOneElement siteOneEl { get; set; }

    }
}