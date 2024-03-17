using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel.Controllers
{
    public class ProductController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        public ActionResult Index()
        {
            return View(db.Products.Where(s=> s.IsDeleted == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase ListImage, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isValidImage = true;
                    string Listname = "";
                    string Imagename = "";
                    if (ListImage != null)
                    {
                        FileInfo fi = new FileInfo(ListImage.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        {
                            Listname = Guid.NewGuid().ToString() + fi.Extension;
                            model.ListImageUrl = Listname;
                        }
                        else{isValidImage = false;}
                    }
                    else{ model.ListImageUrl = "listNone.png";}
                    if (Image != null)
                    {
                        FileInfo fi = new FileInfo(Image.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        {
                            Imagename = Guid.NewGuid().ToString() + fi.Extension;
                            model.ImageUrl = Imagename;
                        }
                        else { isValidImage = false; }
                    }
                    else{model.ImageUrl = "none.png";}
                    if (isValidImage)
                    {
                        ListImage.SaveAs(Server.MapPath("~/Assets/ProductImages/") + Listname);
                        Image.SaveAs(Server.MapPath("~/Assets/ProductImages/") + Imagename);
                        db.Products.Add(model);
                        db.SaveChanges();
                        ViewBag.basarili = "Ürün Başarıyla Eklendi";
                    }
                    else
                    {
                        ViewBag.hata = "Resim Formatı Uygun Değil";
                    }
                }
                catch
                {
                    ViewBag.hata = "Ürün eklenirken bir hata oluştu";
                }
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            return View();
        }
        public ActionResult ChangeStatus(int? id)
        {
            return View();
        }
        public ActionResult Delete(int? id)
        {
            return View();
        }
    }
}