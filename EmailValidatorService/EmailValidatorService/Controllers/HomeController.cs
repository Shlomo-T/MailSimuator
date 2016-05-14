using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmailValidatorService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What";
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the team";

            return View();
        }

        public ActionResult Simulator()
        {
            ViewBag.message = "Welcome to our Email simulator";
            return View();
        }
    }
}