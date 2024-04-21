using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KirtasiyejimWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        KirtasiyejimDBModel db = new KirtasiyejimDBModel();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            int User_ID = 0;
            if (Session["user"] != null)
            {
               User_ID = (Session["user"] as User).ID;

            }
            return View(db.ShoppingCarts.Where(x=> x.User_ID == User_ID));
        }

        public ActionResult AddProduct(string id, string quantity)
        {
            int productid = Convert.ToInt32(id);
            if (Session["user"] != null)
            {
                
                if (db.ShoppingCarts.Count(x=> x.Product_ID == productid) == 0)
                {
                    ShoppingCart sc = new ShoppingCart();
                    sc.Product_ID = productid;
                    sc.Quantity = int.Parse(quantity);
                    sc.User_ID = (Session["user"] as User).ID;
                    sc.AddedDate = DateTime.Now;
                    db.ShoppingCarts.Add(sc);
                    db.SaveChanges();
                }
                else
                {
                    int cartid = db.ShoppingCarts.FirstOrDefault(x => x.Product_ID == productid).ID;
                    ShoppingCart sc = db.ShoppingCarts.Find(cartid);
                    sc.Quantity += int.Parse(quantity);
                    db.SaveChanges();
                }
            }
            else
            {
                TempData["controller"] = "Product";
                TempData["action"] = "Detail";
                TempData["id"] = id;
                return RedirectToAction("Login", "User");
            }
            return RedirectToAction("Detail","Product", new { id= productid });
        }
    }
}