using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NewsController : Controller
    {

        Context db = new Context();

        const int pageSize = 4;
       
        public ActionResult Index(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
               
                return PartialView("NewsPartialView", GetItemsPage(page));
            }
            
                return View(GetItemsPage(page));
            
        }

 
        public ActionResult GetOneNews (int? id)
        {
            
            news News = db.news.Find(id);
            if (News != null)
            {
                return View(News);
            }
            return HttpNotFound();
         
        }

        private List<news> GetItemsPage(int page = 1)
        {
            var itemsToSkip = page * pageSize;        
           return db.news.OrderBy(p => p.siteoneelemId).Skip(itemsToSkip).Take(pageSize).ToList();  // 
           
        }


    }
}