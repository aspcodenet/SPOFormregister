using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormRegister.ViewModels;

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
//            ValidatePersonNummer(model);


            if(!ModelState.IsValid)
            {
                model.RegistrationError = true;
                return View(model);
            }
            model.Saved = true;
            return View(model);
        }

        private void ValidatePersonNummer(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return;
            DateTime dt;
            if (model.PersonNummer.Length == 10 || model.PersonNummer.Length == 11)
            {
                if(!DateTime.TryParseExact(model.PersonNummer.Substring(0,6), "yyMMdd", null,System.Globalization.DateTimeStyles.AssumeLocal,out dt))
                {
                    ModelState.AddModelError("Personnummer", "Felaktigt personnummer");
                }
            }
            else
            {
                if (!DateTime.TryParseExact(model.PersonNummer.Substring(0, 8), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AssumeLocal, out dt))
                {
                    ModelState.AddModelError("Personnummer", "Felaktigt personnummer");
                }
            }


        }
    }
}