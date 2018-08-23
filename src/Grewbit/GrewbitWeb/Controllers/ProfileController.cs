using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrewbitShared.Data;
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
    }
}