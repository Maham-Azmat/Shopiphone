using Shopiphone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopiphone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Message)
        {
            if (Message == null)
            {
                ViewBag.Message = null;
            }
            else
            {
                ViewBag.Message = Message;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(SearchModelView collection)
        {
            string s = collection.type;

            if (collection.type == "Choose brand")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Allitems", new { @brand = collection.type });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult search(SearchModelView collection)
        {
            string search = collection.type;
           // ViewBag.Search = search;
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            List<MobilePhones> list = new List<MobilePhones>();
            var dblist = db.Mobiles.ToList();

            foreach (var i in dblist)
            {
                if (i.Brand == search)
                {
                    MobilePhones mp = new MobilePhones();
                    mp.IME = i.IMEI;
                    mp.Model = i.Model;
                    mp.Brand = i.Brand;
                    mp.Price = i.Price;
                    mp.Warranty = i.Warranty;
                    mp.Description = i.Description;

                    list.Add(mp);
                }

            }
            return View(list);
        }
    }
}