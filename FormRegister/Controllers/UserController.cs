using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormRegister.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            var model = new ViewModels.RegisterViewModel();
            model.MedlemsDatum = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(ViewModels.RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.RegistrationError = true;
                return View(model);
            }
            model.Saved = true;
            return View(model);
        }

    }
}