using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Controllers
{
    public class HomeController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.Where(x=> x.IsActive).ToList());
        }
    }
}