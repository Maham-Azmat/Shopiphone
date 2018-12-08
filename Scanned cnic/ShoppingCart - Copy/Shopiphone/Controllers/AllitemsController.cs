using System;
using Shopiphone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopiphone.Controllers
{
    public class AllitemsController : Controller
    {
        // GET: Allitems
        public ActionResult Index(string brand)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            List<MobilePhones> list = new List<MobilePhones>();
            var dblist = db.Mobiles.ToList();

            foreach (var i in dblist)
            {
                if (i.Brand == brand)
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

        // GET: Allitems/Details/5
        public ActionResult Details(string id)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            MobilePhones m = new MobilePhones();
            var list = db.Mobiles.ToList();
            foreach(var i in list)
            {
                if(i.IMEI == id)
                {
                    m.MobileId = i.MobileId;
                    m.IME = i.IMEI;
                    m.Brand = i.Brand;
                    m.Model = i.Model;
                    m.Warranty = i.Warranty;
                    m.Description = i.Description;
                    m.Price = i.Price;
                    m.Picture = i.Picture;


                }
            }

          

            return View(m);

        }
       
        //public ActionResult Details(int id)
        //{
        //    ShopiphoneEntities1 db = new ShopiphoneEntities1();
            
            
        //    var obj = db.Mobiles.Where(x => x.MobileId == id).First();

        //    return View(obj);
           
        //}

        // GET: Allitems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Allitems/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Allitems/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Allitems/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
        // GET: Allitems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Allitems/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
