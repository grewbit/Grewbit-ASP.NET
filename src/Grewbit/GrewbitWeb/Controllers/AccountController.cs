using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrewbitWeb.ViewModels;
using GrewbitShared.Models;

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
            if (ModelState.IsValid)
            {
                var user = new User { UserName = viewModel.Email, Email = viewModel.Email };
            }
            return View(viewModel);
        }
    }
}