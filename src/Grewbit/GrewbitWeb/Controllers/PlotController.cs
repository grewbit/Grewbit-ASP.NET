using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrewbitShared.Data;
using GrewbitShared.Models;
using Microsoft.AspNet.Identity;

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
            var userId = User.Identity.GetUserId();

            IList<Plot> plots = _plotRepository.GetList(userId);

            return View(plots);
        }

        public ActionResult Add()
        {
            var plot = new Plot();

            plot.UserId = User.Identity.GetUserId();

            return View(plot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Plot plot)
        {
            if (ModelState.IsValid)
            {
                plot.UserId = User.Identity.GetUserId();
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

            var userId = User.Identity.GetUserId();

            Plot plot = _plotRepository.Get(id.Value, userId);

            if (plot == null)
            {
                return HttpNotFound();
            }

            return View(plot);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            Plot plot = _plotRepository.Get(id.Value, userId);

            if (plot == null)
            {
                return HttpNotFound();
            }

            return View(plot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Plot plot)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                if (!_plotRepository.PlotOwnedByUserId(plot.Id, userId))
                {
                    return HttpNotFound();
                }

                plot.UserId = userId;

                _plotRepository.Update(plot);

                TempData["Message"] = "Plot was successfully updated!";

                return RedirectToAction("Detail", new { id = plot.Id});
            }

            return View(plot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var userId = User.Identity.GetUserId();

            if (!_plotRepository.PlotOwnedByUserId(id.Value, userId))
            {
                return HttpNotFound();
            }

            _plotRepository.Delete(id.Value);

            TempData["Message"] = "Plot was successfully deleted!";

            return RedirectToAction("Index");
        }
    }
}