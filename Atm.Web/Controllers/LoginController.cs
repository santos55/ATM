using Atm.Services;
using Atm.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //
        // GET: /Sample/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateCard(CardModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var response = loginService.IsValidCard(model.CardNumber);
            
            if (!response.Success)
            {
                ModelState.AddModelError("INVALID_CARD",response.ErrorMessage);
                return View("Index", model); 
            }
            
            //TODO: Save card context                    
            return RedirectToAction("Pin", "Login", new PinModel { CardNumber = model.CardNumber });
        }


        [ValidateInput(false)]
        public ActionResult Pin(PinModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult ValidatePin(PinModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Pin", model);
            }

            var response = loginService.Login(model.CardNumber, model.Pin);
                
            if (!response.Success)
            {
                ModelState.AddModelError("INVALID_PIN", response.ErrorMessage);
                return View("Pin", model);
            }

            ////TODO: Save card context                    
            //return RedirectToAction("Pin", "Login", new PinModel { CardNumber = model.CardNumber });
            FormsAuthentication.SetAuthCookie(model.CardNumber, false);
            return RedirectToAction("Index", "Operations");          
            
        }


    }
}
