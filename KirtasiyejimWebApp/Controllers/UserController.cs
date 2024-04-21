using KirtasiyejimWebApp.Data;
using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Controllers
{
    public class UserController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User u = db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                    if (u!= null)
                    {
                        if (u.IsActive == true)
                        {
                            Session["user"] = u;
                            if (TempData["controller"]!= null)
                            {
                                return RedirectToAction(TempData["action"].ToString(), TempData["controller"].ToString(), new { id = Convert.ToInt32(TempData["id"]) });
                            }
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.hataMesaj = "Hesabınız askıya alınmıştır";
                        }
                    }
                    else
                    {
                        ViewBag.hataMesaj = "Kullanıcı bulunamadı";
                    }
                }
                catch
                {
                    ViewBag.hataMesaj = "Bir hata oluştu";
                }
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}