using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Data.Entity;




namespace WebApplication1.Controllers
{
    public class PortfolioController : Controller
    {
        // создаем контекст данных
        Context db = new Context();

        public async Task <ActionResult> Index()
        {
            ViewBag.projects = await db.Projects.ToListAsync();

            return View();
        }

        [ChildActionOnly] // to prevent avoke this method from the direct request
        public ActionResult GetCategories()
        {
            List<string> prCat = new List<string>();
            foreach (Project proj in db.Projects.ToList())
            {
                foreach (projectCategory projCateg in proj.projectCats)
                {
                    ViewBag.one = projCateg.Name;
                    /* foreach (string Srt in prCat)
                     {
                         if (Srt != projCateg.Name.ToString () )
                             prCat.Add(projCateg.Name);
                     }
                     */
                    prCat.Add(projCateg.Name);
                }
               
            }

            IEnumerable<string> distinctList = prCat.Distinct();

            
            return PartialView (distinctList);
        }
    }
}