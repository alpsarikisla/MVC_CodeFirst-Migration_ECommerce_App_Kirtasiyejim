using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel.Controllers
{
    public class BrandController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        public ActionResult Index()
        {
            return View(db.Brands.Where(x => x.IsDeleted == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Brands.Add(model);
                    db.SaveChanges();
                    ViewBag.basarili = "Marka Ekleme başarılı";
                }
                catch
                {
                    ViewBag.hata = "Marka eklenirken bir hata oluştu";
                }
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Brand");
            }
            Brand model = db.Brands.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Brand model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.basarili = "Marka güncelleme başarılı";
                }
                catch
                {
                    ViewBag.hata = "Marka güncellenirken bir hata oluştu";
                }
            }
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Brand");
            }
            Brand model = db.Brands.Find(id);

            model.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }

        public ActionResult ChangeStatus(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Brand");
            }
            Brand model = db.Brands.Find(id);

            model.IsActive = !model.IsActive;
            db.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }
    }
}