using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: AdminManagerPanel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}