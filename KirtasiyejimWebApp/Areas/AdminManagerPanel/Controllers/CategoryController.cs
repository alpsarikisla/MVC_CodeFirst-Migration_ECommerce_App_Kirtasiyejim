using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel.Controllers
{
    public class CategoryController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        public ActionResult Index()
        {
            return View(db.Categories.Where(x=> x.IsDeleted ==false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}