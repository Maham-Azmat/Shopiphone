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
        public ActionResult Index()
        {
            ShopiphoneDB db = new ShopiphoneDB();
            Mobile m = new Mobile();
            m.IMEI = "111";
            m.Model = "111";
            m.Warranty = "234";
            m.Used = "890";
            m.Price = "100";
            m.Picture = "234";
            m.Brand = "IPhone";
     
            Mobile n = new Mobile();
            n.IMEI = "111";
            n.Model = "111";
            n.Warranty = "234";
            n.Used = "890";
            n.Price = "100";
            n.Picture = "234";
            n.Brand = "Samsung";

            Mobile a = new Mobile();
            a.IMEI = "111";
            a.Model = "111";
            a.Warranty = "234";
            a.Used = "890";
            a.Price = "100";
            a.Price = "234";
            a.Brand = "IPhone";

            db.Mobiles.Add(m);
            db.Mobiles.Add(n);
            db.Mobiles.Add(a);
            db.SaveChanges();



            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchModelView collection)
        {
            string s = collection.type;

            return RedirectToAction("Index", "Allitems", new { @brand = collection.type });
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
            ShopiphoneDB db = new ShopiphoneDB();
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

                    list.Add(mp);
                }

            }
            return View(list);
        }
    }
}