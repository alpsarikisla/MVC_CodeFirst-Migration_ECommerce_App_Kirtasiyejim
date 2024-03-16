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
            return View(db.Categories.Where(x=> x.IsDeleted == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
               try
                {
                    db.Categories.Add(model);
                    db.SaveChanges();
                    ViewBag.basarili = "Kategori Ekleme başarılı";
                }
                catch
                {
                    ViewBag.hata = "Kategori eklenirken bir hata oluştu";
                }
            }
            
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Category");
            }
            Category model = db.Categories.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.basarili = "Kategori güncelleme başarılı";
                }
                catch
                {
                    ViewBag.hata = "Kategori güncellenirken bir hata oluştu";
                }
            }
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Category");
            }
            Category model = db.Categories.Find(id);
           
            model.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        public ActionResult ChangeStatus(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Category");
            }
            Category model = db.Categories.Find(id);
           
            model.IsActive = !model.IsActive;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}