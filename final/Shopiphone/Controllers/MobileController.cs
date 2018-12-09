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
    public class MobileController : Controller
    {
        // GET: Mobile
        public ActionResult Index()
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            List<MobilePhones> list = new List<MobilePhones>();
            var dblist = db.Mobiles.ToList();
            foreach (var i in dblist)
            {
                MobilePhones mp = new MobilePhones();
                mp.IME = i.IMEI;
                mp.Model = i.Model;
                mp.Brand = i.Brand;
                mp.Price = i.Price;
                mp.Warranty = i.Warranty;
                list.Add(mp);
            }
            return View(list);
        }

        // GET: Mobile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mobile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mobile/Create
        [HttpPost]
        public ActionResult Create(MobilePhones collection,SearchModelView c)
        {
            //try
            //{
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            
            List<string> temp = new List<string>();
            string t = null;
            foreach(char tr in collection.IME)
            {
                if (tr!=',')
                {
                    t = t + tr.ToString();
                    
                }
                else 
                {
                    temp.Add(t);
                    t = null;
              
                }
                
            }
            temp.Add(t);
            for (int i = 0; i < temp.Count(); i++)
            {
                Mobile obj = new Mobile();
                obj.IMEI = temp[i];
                obj.Model = collection.Model;
                obj.Brand = c.type;
                obj.Warranty = collection.Warranty;
                obj.Price = collection.Price;
                string fileName = Path.GetFileName(collection.ImageFile.FileName);
                string extension = Path.GetExtension(collection.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                collection.Picture = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                collection.ImageFile.SaveAs(fileName);
                obj.Picture = collection.Picture;
                obj.Warranty = collection.Warranty;
                db.Mobiles.Add(obj);
                db.SaveChanges();
            }
                return RedirectToAction("Index", "Admin");

               
            
            //catch(Exception ex)
            //{
            //    throw ex;
               
            //}
        }

        // GET: Mobile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mobile/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MobilePhones collection, SearchModelView c)
        {
            try
            {

                // TODO: Add update logic here
                ShopiphoneEntities1 db = new ShopiphoneEntities1();
                var obj = db.Mobiles.Where(x => x.IMEI == id).FirstOrDefault();
                obj.IMEI = collection.IME;
                obj.Model = collection.Model;
                obj.Warranty = collection.Warranty;
                obj.Brand = c.type;
                obj.Price = collection.Price;
                db.SaveChanges();

                //MobilePhones model = new MobilePhones();
                //model.Mobiles = db.Customers.OrderBy(
                //              m => m.CustomerID).Take(5).ToList();

                //model.SelectedCustomer = existing;
                //model.DisplayMode = "ReadOnly";
                return View("Index","Admin");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Mobile/Delete/5
        public ActionResult Delete(string id)
        {
            ShopiphoneEntities1 db = new ShopiphoneEntities1();
            var item = db.Mobiles.Where(x => x.IMEI == id).SingleOrDefault();
            db.Mobiles.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        // POST: Mobile/Delete/5
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
