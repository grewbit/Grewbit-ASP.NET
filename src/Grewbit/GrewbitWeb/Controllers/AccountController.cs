using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrewbitWeb.ViewModels;

namespace GrewbitWeb.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AccountSignUpViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}