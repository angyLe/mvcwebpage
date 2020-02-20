using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;


namespace WebApplication1.Models
{
    public interface IEmailProcessor
    {
        bool Sent();
    }
}