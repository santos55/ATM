using Atm.Services;
using Atm.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Atm.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }  

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateCard(CardModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var cardNumber = model.CardNumber.Any(p => p == '-') ? model.CardNumber.Replace("-", string.Empty) : model.CardNumber;
            var response = loginService.IsValidCard(cardNumber);
            
            if (!response.Success)
            {
                ModelState.AddModelError("INVALID_CARD",response.ErrorMessage);
                return View("Index", model); 
            }

            Session["CardNumber"] = cardNumber;
            return RedirectToAction("Pin");
        }

        public ActionResult Pin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ValidatePin(PinModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Pin", model);
            }

            var response = loginService.Login(Session["CardNumber"].ToString(), model.Pin);
                
            if (!response.Success)
            {
                ModelState.AddModelError("INVALID_PIN", response.ErrorMessage);
                return View("Pin", model);
            }

            return RedirectToAction("Index", "Operation");          
            
        }

        public ActionResult Exit()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
