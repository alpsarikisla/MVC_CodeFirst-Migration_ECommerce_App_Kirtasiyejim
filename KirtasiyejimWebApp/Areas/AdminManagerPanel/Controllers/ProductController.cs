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
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Products.Add(model);
                    db.SaveChanges();
                    ViewBag.basarili = "Ürün Başarıyla Eklendi";
                }
                catch
                {
                    ViewBag.hata = "Ürün eklenirken bir hata oluştu";
                }
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            return RedirectToAction("InsertImage", "Product", new { id = model.ID });
        }

        [HttpGet]
        public ActionResult InsertImage(int id)
        {
            Product p = db.Products.Find(id);
            ViewBag.product = p;
            return View();
        }
        [HttpPost]
        public ActionResult InsertImage(int id, HttpPostedFileBase Image)
        {
            bool isValidImage = true;
            ProductImage model = new ProductImage();
            FileInfo fi = new FileInfo(Image.FileName);
            string ImageName = "";
            if (fi.Extension == ".jpg" || fi.Extension == ".png")
            {
                ImageName = Guid.NewGuid().ToString() + fi.Extension;
                model.ImageUrl = ImageName;
            }
            else { isValidImage = false; }

            if (isValidImage)
            {
                Image.SaveAs(Server.MapPath("~/Assets/ProductImages/"+ ImageName));
                model.Product_ID = id;
                db.ProductImages.Add(model);
                db.SaveChanges();
                ViewBag.basarili = "Resim Eklendi";
            }
            else
            {
                ViewBag.hata = "Resim Formatı Uygun Değil";
            }
            return RedirectToAction("InsertImage", "Product", new { id = id });

        }
        public ActionResult KapakResmiYap(int id)
        {
            ProductImage pi = db.ProductImages.Find(id);
            List<ProductImage> pilist = db.ProductImages.Where(x => x.Product_ID == pi.Product_ID).ToList();
            foreach (ProductImage item in pilist)
            {
                ProductImage pi3 = db.ProductImages.Find(item.ID);
                pi3.isListImage = false;
                db.SaveChanges();
            }
           
            ProductImage pi2 = db.ProductImages.Find(id);
            pi2.isListImage = true;
            db.SaveChanges();
            return RedirectToAction("InsertImage", "Product", new { id = pi.Product.ID });
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