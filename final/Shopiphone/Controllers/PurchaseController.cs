using System;
using Shopiphone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Shopiphone.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            List<PurchaseItems> lists = new List<PurchaseItems>();
            var dblist = db.Purchase_Items.ToList();
            foreach (var i in dblist)
            {
                PurchaseItems mp = new PurchaseItems();
                mp.Name = i.CustomerName;
                mp.CNIC = i.CNIC;
                mp.MobileNumber = i.PhoneNumber;
                mp.IME = i.IMEI;
                mp.Model = i.Model;
                mp.Brand = i.Brand;
                mp.Price = i.Price;
                mp.Description = i.Description;

                mp.Warranty = i.Warranty;
                lists.Add(mp);
            }
            return View(lists);
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Bargain(string id, Secondhandviewmodel c)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            var item = db.secondhandphones.Where(x => x.IMEI == id).SingleOrDefault();
            db.secondhandphones.Remove(item);
            var obj = item;
            TempData["total"] = obj.Price;
            item.BargainPrice = c.Price;
            db.secondhandphones.Add(item);


            return RedirectToAction("Index", "Mobile");
        }

        // POST: Purchase/Create
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

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Purchase/Edit/5
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

        // GET: Purchase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Purchase/Delete/5
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
        public ActionResult Purchaselist(string id)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            // TODO: Add insert logic here
            Purchase_Items obj = new Purchase_Items();
            secondhandphone m = new secondhandphone();
            var i = db.secondhandphones.ToList();
            foreach (var s in i)
            {
                if (id == s.IMEI)
                {
                    obj.IMEI = s.IMEI;
                    obj.Model = s.Model;
                    obj.CustomerName = s.CustomerName;
                    obj.Description = s.Description;
                    obj.Warranty = s.Warranty;
                    obj.Price = s.Price;
                    obj.Picture = s.Picture;
                    obj.PhoneNumber = s.PhoneNumber;
                    obj.Brand = s.Brand;
                    obj.CNIC = s.CNIC;
                }
            }
            db.Purchase_Items.Add(obj);
            db.SaveChanges();


            var item = db.secondhandphones.Where(x => x.IMEI == id).SingleOrDefault();
            db.secondhandphones.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index", "Mobile");
        }
    }
}
