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
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index(string id)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            Cart obj = new Cart();
            
            var list = db.Mobiles.ToList();
            foreach (var i in list)
            {
                if (i.IMEI == id)
                {
                    obj.MobileId = i.MobileId;
                    obj.IMEI = i.IMEI;
                    obj.Brand = i.Brand;
                    obj.Model = i.Model;
                    obj.Warranty = i.Warranty;
                    obj.Description = i.Description;
                    obj.Price = i.Price;
                    obj.Picture = i.Picture;
                    db.Carts.Add(obj);
                    db.SaveChanges();
                    
                    
                }
            }
            List<MobilePhones> lists = new List<MobilePhones>();
            var dblist = db.Carts.ToList();
            foreach (var i in dblist)
            {
                MobilePhones mp = new MobilePhones();
                mp.IME = i.IMEI;
                mp.Model = i.Model;
                mp.Brand = i.Brand;
                mp.Price = i.Price;
                mp.Warranty = i.Warranty;
                lists.Add(mp);
            }
            return View(lists);
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        int total;
        // GET: ShoppingCart/Details/5
        public ActionResult OrderNow(string id, MobilePhones collection)
        {
           
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            var list = db.Carts.ToList();
            foreach (var i in list)
            {
                if (i.IMEI == id)
                {
                    total = int.Parse(i.Price);
                    total = total + 100;
                }

            }
            TempData["total"] = total;
            return View();
        }
        [HttpPost]
        public ActionResult OrderNow(string  id)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            Sold_Items obj = new Sold_Items();
            var list = db.Sold_Items.ToList();
            var lists = db.Mobiles.ToList();
            string userid = User.Identity.GetUserId();
            var person = db.AspNetUsers.Where(y => y.Id == userid).First();
            obj.CustomerName = person.Name;
            obj.CNIC = person.CNIC;
            obj.PhoneNumber = person.PhoneNumber;
            obj.Scanned_CNIC = person.Scanned_CNIC;

            foreach (var i in lists)
            {
                if (i.IMEI == id)
                {
                    obj.MobileId = i.MobileId;
                    obj.IMEI = i.IMEI;
                    obj.Brand = i.Brand;
                    obj.Model = i.Model;
                    obj.Warranty = i.Warranty;
                    obj.Description = i.Description;
                    obj.Price = i.Price;
                    obj.Picture = i.Picture;
                    obj.Date = DateTime.Now;
                    db.Sold_Items.Add(obj);
                    db.SaveChanges();
                }
            }

            var item = db.Carts.Where(x => x.IMEI == id).SingleOrDefault();
            db.Carts.Remove(item);
            db.SaveChanges();

            var item2 = db.Mobiles.Where(x => x.IMEI == id).SingleOrDefault();
            db.Mobiles.Remove(item2);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult OrderNowwithoutusingcart(string id, MobilePhones collection)
        {

            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            var list = db.Carts.ToList();
            foreach (var i in list)
            {
                if (i.IMEI == id)
                {
                    total = int.Parse(i.Price);
                    total = total + 100;
                }

            }
            TempData["tota"] = total;
            return View();
        }
        [HttpPost]
        public ActionResult OrderNowwithoutusingcart(string id)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            Sold_Items obj = new Sold_Items();
            var list = db.Sold_Items.ToList();
            var lists = db.Mobiles.ToList();
            string userid = User.Identity.GetUserId();
            var person = db.AspNetUsers.Where(y => y.Id == userid).First();
            obj.CustomerName = person.Name;
            obj.CNIC = person.CNIC;
            obj.PhoneNumber = person.PhoneNumber;

            foreach (var i in lists)
            {
                if (i.IMEI == id)
                {
                    obj.MobileId = i.MobileId;
                    obj.IMEI = i.IMEI;
                    obj.Brand = i.Brand;
                    obj.Model = i.Model;
                    obj.Warranty = i.Warranty;
                    obj.Description = i.Description;
                    obj.Price = i.Price;
                    obj.Picture = i.Picture;
                    obj.Date = DateTime.Now;
                    db.Sold_Items.Add(obj);
                    db.SaveChanges();
                }
            }

            var item2 = db.Mobiles.Where(x => x.IMEI == id).SingleOrDefault();
            db.Mobiles.Remove(item2);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
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

        // GET: ShoppingCart/Edit/5
        public ActionResult Soldlist()
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            List<solditems> lists = new List<solditems>();
            var dblist = db.Sold_Items.ToList();
            foreach (var i in dblist)
            {
                solditems mp = new solditems();
                mp.Name = i.CustomerName;
                mp.CNIC = i.CNIC;
                mp.MobileNumber = i.PhoneNumber;
                mp.IME = i.IMEI;
                mp.Model = i.Model;
                mp.Brand = i.Brand;
                mp.Price = i.Price;
                mp.Warranty = i.Warranty;
                lists.Add(mp);
            }
            return View(lists);
        }

        // POST: ShoppingCart/Edit/5
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

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(string id)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            var item = db.Carts.Where(x => x.IMEI == id).SingleOrDefault();
            db.Carts.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ShoppingCart/Delete/5
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
