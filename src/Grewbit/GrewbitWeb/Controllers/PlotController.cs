using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrewbitShared.Data;
using GrewbitShared.Models;

namespace GrewbitWeb.Controllers
{
    public class PlotController : Controller
    {
        private PlotRepository _plotRepository = null;

        public PlotController(PlotRepository plotRepository)
        {
            _plotRepository = plotRepository;
        }

        public ActionResult Index()
        {
            IList<Plot> plots = _plotRepository.GetList();

            return View(plots);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Plot plot)
        {
            if (ModelState.IsValid)
            {
                _plotRepository.Add(plot);

                TempData["Message"] = "Plot was successfully added!";

                return RedirectToAction("Index");
            }

            return View(plot);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Plot plot = _plotRepository.Get(id.Value);

            if (plot == null)
            {
                return HttpNotFound();
            }

            return View(plot);
        }
    }
}