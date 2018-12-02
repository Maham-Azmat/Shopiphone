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
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            ShopiphoneEntities db = new ShopiphoneEntities();
            List<Secondhandviewmodel> list = new List<Secondhandviewmodel>();
            var dblist = db.secondhandphones.ToList();

            foreach (var i in dblist)
            {
                
                    Secondhandviewmodel mp = new Secondhandviewmodel();
                    mp.Name = i.CustomerName;
                    mp.CNIC = i.CNIC;
                    mp.MobileNumber = i.PhoneNumber;
                    mp.IME = i.IMEI;
                    mp.Model = i.Model;
                    mp.Brand = i.Brand;
                    mp.Price = i.Price;
                    mp.Warranty = i.Warranty;
                    mp.Used = i.Used;
                    list.Add(mp);
            }
            return View(list);
        }

        // GET: Second/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Second/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Second/Create
        [HttpPost]
        public ActionResult Create(Secondhandviewmodel collection)
        {
            //try
            //{
                // TODO: Add insert logic here
                ShopiphoneEntities db = new ShopiphoneEntities();
                secondhandphone obj = new secondhandphone();
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
                obj.Picture = collection.Picture;
                obj.Used = collection.Used;

                //RegisterViewModel loggedinuser = new RegisterViewModel();
                string userid = User.Identity.GetUserId();
                var person = db.AspNetUsers.Where(y => y.Id == userid).First();
                obj.CustomerName = person.Name;
                obj.CNIC = person.CNIC;
                obj.PhoneNumber = person.PhoneNumber;

                db.secondhandphones.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Second/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Second/Edit/5
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

        // GET: Second/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Second/Delete/5
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
