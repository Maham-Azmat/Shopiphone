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
    public class secondhandphoneController : Controller
    {
        // GET: secondhandphone
        public ActionResult Index()
        {
            ShopiphoneEntities db = new ShopiphoneEntities();
            List<secondhand> list = new List<secondhand>();
            var dblist = db.Mobiles.ToList();
            foreach (var i in dblist)
            {
                secondhand mp = new secondhand();
                mp.IME = i.IMEI;
                mp.Model = i.Model;
                mp.Brand = i.Brand;
                mp.Price = i.Price;
                mp.Warranty = i.Warranty;
                list.Add(mp);
            }
            return View(list);
         
        }

        // GET: secondhandphone/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: secondhandphone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: secondhandphone/Create
        [HttpPost]
        public ActionResult Create(secondhand collection)
        {
            try
            {
                // TODO: Add insert logic here
                ShopiphoneEntities db = new ShopiphoneEntities();
                Mobile obj = new Mobile();
                obj.IMEI = collection.IME;
                obj.Model = collection.Model;
                obj.Brand = collection.Brand;
                //obj.Warranty = collection.Warranty;
                obj.Price = collection.Price;
                string fileName = Path.GetFileName(collection.ImageFile.FileName);
                string extension = Path.GetExtension(collection.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                collection.Picture = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                collection.ImageFile.SaveAs(fileName);
                obj.Used = collection.Picture;
                db.Mobiles.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: secondhandphone/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: secondhandphone/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, secondhand collection)
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

        // GET: secondhandphone/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: secondhandphone/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, secondhand collection)
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
