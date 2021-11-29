using Gig.Models;
using Gig.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gig.MVC.Controllers
{
    public class GigApplyController : Controller
    {
        // GET: GigApply
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GigApplyService(userId);
            var model = service.GetGigApply();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigApplyCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateGigApplyService();

            if (service.CreateGigApply(model))
            {
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Gig not applied for");

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateGigApplyService();
            var model = svc.GetGigApplyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGigApplyService();
            var detail = service.GetGigApplyById(id);
            var model =
                new GigApplyEdit
                {
                    GigApplyId = detail.GigApplyId,
                    GigPostId = detail.GigPostId,
                    ProfileId = detail.ProfileId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GigApplyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GigApplyId != id)
            {
                ModelState.AddModelError("", "id no good");
                return View(model);
            }

            var service = CreateGigApplyService();

            if (service.UpdateGigApply(model))
            {
                TempData["SaveResult"] = "gig apply Was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "gig apply was not updated");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGigApplyService();
            var model = svc.GetGigApplyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGigApplyService();

            service.DeleteGigApply(id);

            TempData["SaveResult"] = "Your work history Was Deleted";

            return RedirectToAction("Index");
        }

        private GigApplyService CreateGigApplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GigApplyService(userId);
            return service;
        }
    }
}