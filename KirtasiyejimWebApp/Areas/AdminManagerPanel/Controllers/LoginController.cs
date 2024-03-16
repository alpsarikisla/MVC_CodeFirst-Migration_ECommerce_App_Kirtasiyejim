using KirtasiyejimWebApp.Areas.AdminManagerPanel.Data;
using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel.Controllers
{
    public class LoginController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();

        // GET: AdminManagerPanel/Login
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(ManagerLoginViewModel model)
        {
            if (ModelState.IsValid)//Validasyonların tamamı sağlanıyorsa
            {
                Manager m = db.Managers.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["manager"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.hataMesaj = "Kullanıcı hesabınız askıya alındı";
                    }
                }
                else
                {
                    ViewBag.hataMesaj = "Kullanıcı bulunamadı. Lütfen girdiğiniz bilgileri kontrol ediniz";
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["manager"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}