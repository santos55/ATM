using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atm.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Balance()
        {
            ViewBag.Message = "Balance";

            return View();
        }

        public ActionResult Withdrawal()
        {
            ViewBag.Message = "Your Withdrawal page.";

            return View();
        }
    }
}