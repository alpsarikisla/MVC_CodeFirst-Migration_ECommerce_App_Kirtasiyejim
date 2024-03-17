using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel.Controllers
{
    public class HomeController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        public ActionResult Index()
        {
            ViewBag.kategorisayi = db.Categories.Count();
            ViewBag.urunsayi =db.Products.Count();
            ViewBag.uyesayi = 0;
            ViewBag.kazanc = 0;
            return View();
        }
    }
}