using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class NewsController : Controller
    {
        Context db = new Context();
        const int pageSize = 4;

        public async Task<ActionResult> Index(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {

                return PartialView("NewsPartialView", GetItemsPage(page));
            }

            return View(await GetItemsPage(page));
        }

        public async Task<ActionResult> GetOneNews(int? id)
        {

            News News = await db.News.FindAsync(id);
            if (News != null)
            {
                return View(News);
            }

            return HttpNotFound();
        }

        private async Task<IList<News>> GetItemsPage(int page = 1)
        {
            var itemsToSkip = page * pageSize;
            return await db.News.Include(n => n.ImageLink).OrderBy(p => p.NewsId).Skip(itemsToSkip).Take(pageSize).ToListAsync();
        }
    }
}