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
    public class WorkHistoryController : Controller
    {
        // GET: WorkHistory
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkHistoryService(userId);
            var model = service.GetWorkHistory();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkHistoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var service = CreateWorkHistoryService();

            if (service.CreateWorkHistory(model))
            {
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "job was not added");

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateWorkHistoryService();
            var model = svc.GetWorkHistoryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateWorkHistoryService();
            var detail = service.GetWorkHistoryById(id);
            var model =
                new WorkHistoryEdit
                {
                    ProfileId = detail.ProfileId,
                    Company = detail.Company,
                    TimeWorked = detail.TimeWorked,
                    JobDescription = detail.JobDescription,
                    JobTitle = detail.JobTitle,
                    WorkHistoryId = detail.WorkHistoryId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkHistoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.WorkHistoryId != id)
            {
                ModelState.AddModelError("", "id no good");
                return View(model);
            }

            var service = CreateWorkHistoryService();

            if (service.UpdateWorkHistory(model))
            {
                TempData["SaveResult"] = "Work History Was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "job was not updated");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkHistoryService();
            var model = svc.GetWorkHistoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWorkHistoryService();

            service.DeleteWorkHistory(id);

            TempData["SaveResult"] = "Your work history Was Deleted";

            return RedirectToAction("Index");
        }

        private WorkHistoryService CreateWorkHistoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkHistoryService(userId);
            return service;
        }
    }
}