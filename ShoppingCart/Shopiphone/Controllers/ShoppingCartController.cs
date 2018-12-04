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
        public ActionResult Edit(int id)
        {
            return View();
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
