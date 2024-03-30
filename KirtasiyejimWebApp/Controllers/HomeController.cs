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

        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                string categoryName = db.Categories.Find(id).Name;
                ViewBag.Title = categoryName;
                return View(db.Products.Where(x => x.IsActive && x.Category_ID == id).ToList());
            }
            else
            {
                ViewBag.Title = "Anasayfa";
                return View(db.Products.Where(x => x.IsActive).ToList());
            }
            
        }

        //public ActionResult CategoryProducts(int id)
        //{
        //    return View(db.Products.Where(x => x.IsActive && x.Category_ID == id).ToList());
        //}
    }
}