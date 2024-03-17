using KirtasiyejimWebApp.Areas.AdminManagerPanel.Data;
using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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
            HttpCookie cookie = Request.Cookies["adminCookie"];
            if (cookie != null)
            {
                string email = cookie["Email"].ToString();
                string password = cookie["password"].ToString();
                Manager m = db.Managers.FirstOrDefault(x => x.Email ==  email && x.Password == password);
                Session["manager"] = m;
                return RedirectToAction("Index", "Home");
            }
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
                        if (model.RememberMe)
                        {
                            HttpCookie cookie = new HttpCookie("adminCookie");
                            cookie["Email"] = model.Email;
                            cookie["password"] = model.Password;
                            cookie.Expires = DateTime.Now.AddDays(10);
                            Response.Cookies.Add(cookie);
                        }
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
            HttpCookie cookie = Request.Cookies["adminCookie"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Session["manager"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}