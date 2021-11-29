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
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            var model = service.GetProfiles();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProfile model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProfileService();

            if (service.CreateProfile(model))
            {
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Profile is a no go");

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProfileService();
            var detail = service.GetProfileById(id);
            var model =
                new ProfileEdit
                {
                    ProfileId = detail.ProfileId,
                    Name = detail.Name,
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State,
                    
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProfileEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProfileId != id)
            {
                ModelState.AddModelError("", "id no good");
                return View(model);
            }

            var service = CreateProfileService();

            if (service.UpdateProfile(model))
            {
                TempData["SaveResult"] = "profile Was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Profile was not updated");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProfileService();

            service.DeleteProfile(id);

            TempData["SaveResult"] = "Your Profile Was Deleted";

            return RedirectToAction("Index");
        }


        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            return service;
        }
    }
}