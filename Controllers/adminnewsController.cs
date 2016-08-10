using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class adminnewsController : Controller
    {
        private Context db = new Context();

        // GET: adminnews
        public async Task<ActionResult> Index()
        {
            return View(await db.news.ToListAsync());
        }

        [ChildActionOnly]
        public ActionResult GetImages(int NewsId)
        {
         
            news OneNews =  db.news.Find(NewsId);
            
                ViewBag.Title = OneNews.Title;

            
                ViewBag.Title = null;
            ViewBag.images = OneNews.imgLink;
           
            //List  <imageLink> Newsimages = await OneNews.imgLink.
            return PartialView ("GetImages"); 
        }

        // GET: adminnews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = await db.news.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: adminnews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: adminnews/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "siteoneelemId,Title,Text,Anonce")] news news)
        {
            if (ModelState.IsValid)
            {
                db.oneElements.Add(news);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: adminnews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = await db.news.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: adminnews/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "siteoneelemId,Title,Text,Anonce")] news news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: adminnews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = await db.news.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: adminnews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            news news = await db.news.FindAsync(id);
            db.oneElements.Remove(news);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
