using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Controllers
{
    public class MenuController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        // GET: Menu
        public ActionResult _menuView()
        {
            return PartialView(db.Categories.Where(x=> x.IsActive).ToList());
        }
    }
}