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
            return View();
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
        public ActionResult Create(MobilePhones collection)
        {
            try
            {

                ShopiphoneEntities db = new ShopiphoneEntities();
                // TODO: Add insert logic here
                if (collection.Brand == "Samsung")
                {

                    Samgsung obj = new Samgsung();
                    obj.IMEI = collection.IME;
                    obj.Model = collection.Model;
                    //obj.Warranty = collection.Warranty;
                    obj.Price = collection.Price;
                    string fileName = Path.GetFileName(collection.ImageFile.FileName);
                    string extension = Path.GetExtension(collection.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    collection.Picture = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    collection.ImageFile.SaveAs(fileName);
                    obj.Used = collection.Picture;
                    db.Samgsungs.Add(obj);
                    db.SaveChanges();
                }
                else if (collection.Brand == "Apple")
                {

                    IPhone obj = new IPhone();
                    obj.IMEI = collection.IME;
                    obj.Model = collection.Model;
                    //obj.Warranty = collection.Warranty;
                    obj.Price = collection.Price;
                    string fileName = Path.GetFileName(collection.ImageFile.FileName);
                    string extension = Path.GetExtension(collection.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    collection.Picture = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    collection.ImageFile.SaveAs(fileName);
                    obj.Used = collection.Picture;
                    db.IPhones.Add(obj);
                    db.SaveChanges();
                }
                else
                {

                    Huawei obj = new Huawei();
                    obj.IMEI = collection.IME;
                    obj.Model = collection.Model;
                    //obj.Warranty = collection.Warranty;
                    obj.Price = collection.Price;
                    string fileName = Path.GetFileName(collection.ImageFile.FileName);
                    string extension = Path.GetExtension(collection.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    collection.Picture = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    collection.ImageFile.SaveAs(fileName);
                    obj.Used = collection.Picture;
                    db.Huaweis.Add(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("Index","Admin");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Mobile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mobile/Edit/5
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

        // GET: Mobile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
