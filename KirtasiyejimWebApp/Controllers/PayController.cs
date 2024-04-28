using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Controllers
{
    public class PayController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        [HttpGet]
        public ActionResult Index()
        {
            int User_ID = 0;
            if (Session["user"] != null)
            {
                User_ID = (Session["user"] as User).ID;
            }
            return View(db.ShoppingCarts.Where(x => x.User_ID == User_ID));
        }
        [HttpPost]
        public ActionResult Index(string name, string cardnumber, string reqmonth, string reqyear, string cvv)
        {
            int User_ID = 0;
            if (Session["user"] != null)
            {
                User_ID = (Session["user"] as User).ID;
            }
            List<ShoppingCart> list = db.ShoppingCarts.Where(x => x.User_ID == User_ID).ToList();
            double total = list.Sum(x => x.Product.Price * x.Quantity);
            return View();
        }
    }
}