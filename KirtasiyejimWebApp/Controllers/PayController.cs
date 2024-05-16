using KirtasiyejimWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            string fiyatstr = total.ToString().Replace(",", ".");
            string apiurl = "https://localhost:44386/API/Pay?kartno=" + cardnumber + "&sonkullanmaAy=" + reqmonth + "&sonkullanmayil=" + reqyear + "&CVV=" + cvv + "&fiyat=" + fiyatstr;
            //using System.Net.Http;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiurl).Result;
            var strinResp = response.Content.ReadAsStringAsync();
            if (strinResp.Result == "\"201\"")
            {
                return RedirectToAction("PaymentSuccess");
            }
            else if (strinResp.Result == "\"901\"")
            {
                ViewBag.message = "Kart Numarası Hatalı Girildi";
            }
            else if (strinResp.Result == "\"801\"")
            {
                ViewBag.message = "Kart Tarihi Eşleşmesi";
            }
            else if (strinResp.Result == "\"701\"")
            {
                ViewBag.message = "Banka Mesajı = Kart Tarihi Geçersiz";
            }
            else if (strinResp.Result == "\"601\"")
            {
                ViewBag.message = "Banka Mesajı =Cvv Hatalı";
            }
            else if (strinResp.Result == "\"501\"")
            {
                ViewBag.message = "Banka Mesajı = Kart Aktif Değil";
            }
            else if (strinResp.Result == "\"401\"")
            {
                ViewBag.message = "Banka Mesajı = Kart Bakiyesi yetersiz";
            }
            else if (strinResp.Result == "\"301\"")
            {
                ViewBag.message = "Banka Mesajı = Bir Hata oluştu";
            }
            return View(db.ShoppingCarts.Where(x => x.User_ID == User_ID));
        }
        
    }
}