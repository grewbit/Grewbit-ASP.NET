using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadAvatar(string id, HttpPostedFileBase Avatar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Avatar != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UserPhotos"), Path.GetFileName(Avatar.FileName));
                        Avatar.SaveAs(path);

                        var userProfile = _userProfileRepository.Get(id);
                        userProfile.Avatar = Avatar.FileName;
                        _userProfileRepository.Update(userProfile);

                        TempData["Message"] = "Avatar was successfully updated!";

                        return RedirectToAction("Index");
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    TempData["Message"] = "Can't update avatar, try again!";

                    return RedirectToAction("Index");
                }
            }

            return View("Edit", _userProfileRepository.Get(id));
        }
    }
}