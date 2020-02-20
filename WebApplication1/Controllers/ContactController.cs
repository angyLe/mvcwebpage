using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ContactInfo());
        }

        [HttpPost]
        public ViewResult Index(ContactInfo info)
        {
            if (ModelState.IsValid)
            {

                return View("Complete", info);
            }
            else
            {
                return View(); //todo
            }

        }
    }
}