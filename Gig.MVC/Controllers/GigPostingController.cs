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
    [Authorize]
    public class GigPostingController : Controller
    {
        // GET: GigPosting
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GigPostingService(userId);
            var model = service.GetGigPosting();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AllGig()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GigPostingService(userId);
            var model = service.GetAllGigPosting();

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigPostingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGigPostingService();

            if (service.CreateGigPosting(model))
            {
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Gig not Posted");

            return View(model);


        }

        public ActionResult Detail(int id)
        {
            var svc = CreateGigPostingService();
            var model = svc.GetGigPostingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGigPostingService();
            var detail = service.GetGigPostingById(id);
            var model =
                new GigPostingEdit
                {
                    GigPostId = detail.GigPostId,
                    PayPerHour = detail.PayPerHour,
                    DescriptionOfJob = detail.DescriptionOfJob,
                    Location = detail.Location,
                    JobTitle = detail.JobTitle,
                    
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GigPostingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GigPostId != id)
            {
                ModelState.AddModelError("", "id no good");
                return View(model);
            }

            var service = CreateGigPostingService();

            if (service.UpdateGigposting(model))
            {
                TempData["SaveResult"] = "Gig Posting Was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "gig was not updated");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGigPostingService();
            var model = svc.GetGigPostingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGigPostingService();

            service.DeleteGigPosting(id);

            TempData["SaveResult"] = "Your work history Was Deleted";

            return RedirectToAction("Index");
        }

        private GigPostingService CreateGigPostingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GigPostingService(userId);
            return service;
        }
    }
}