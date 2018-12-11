using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopiphone.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string Message)
        {
            if (Message != null)
            {
                ViewBag.Message = Message;
            }
            else
            {
                ViewBag.Message = null;
            }
            return View();
        }
    }
}