using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrewbitShared.Data;
using GrewbitShared.Models;
using Microsoft.AspNet.Identity;

namespace GrewbitWeb.Controllers
{
    public class ProfileController : Controller
    {
        private UserProfileRepository _userProfileRepository = null;

        public ProfileController(UserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public ActionResult Index()
        {
            var userProfile = _userProfileRepository.Get(User.Identity.GetUserId());

            return View(userProfile);
        }

        public ActionResult Edit()
        {
            var userProfile = _userProfileRepository.Get(User.Identity.GetUserId());

            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _userProfileRepository.Update(userProfile);
                TempData["Message"] = "Profile was successfully updated!";

                return RedirectToAction("Index");
            }

            return View(userProfile);
        }
    }
}