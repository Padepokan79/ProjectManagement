using ProjectManagement.Entites;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectManagement.Controllers
{
    public class EditProjectController : Controller
    {
        private ProjectManagementDbContext db = new ProjectManagementDbContext();

        public ActionResult EditProject()
        {
                ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");
                ViewBag.ProjectStatusId = new SelectList(db.ProjectStatus, "ProjectStatusId", "Description");
                ViewBag.PIC = new SelectList(db.Projects, "PIC", "PIC");

                return View();
        }

        [HttpPost]
        public JsonResult GetModul() {
            var data = db.Moduls.Select(s => new ModulViewModel
            {
                ModulNumber=s.ModulNumber,
                ModulName=s.ModulName,
                Description=s.Description,
                PIC=s.PIC,
            }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetProjectDoc()
        {
            var data = db.ProjectDocuments.Select(s => new ProjectDocumentViewModel
            {
                DocumentTypeId=s.DocumentTypeId,
                DocumentName=s.DocumentName,
                FilePath=s.FilePath,
                Version=s.Version
            }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetRequirement()
        {
            var data = db.Requirements.Select(s => new RequirementViewModel
            {
                RequimentTypeId=s.RequimentTypeId,
                RequirementNumber=s.RequirementNumber,
                Description=s.Description,
                Level=s.Level

            }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetSchedule()
        {
            var data = db.ProjectSchedules.Select(s => new ProjectScheduleViewModel
            {
                ProjectId=s.ProjectId,
                Version=s.Version,

            }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Update(ProjectViewModel project) {
            Project p = db.Projects.Find(project.ProjectId);
            p.ProjectName = project.ProjectName;
            p.PIC = project.PIC;
            p.ProjectStatusId = project.ProjectStatusId;
            p.StartDateActual = project.StartDateActual;
            p.EndDateActual = project.EndDateActual;
            p.ClientId = project.ClientId;
            p.StartDatePlan = project.StartDatePlan;
            p.EndDatePlan = project.EndDatePlan;
            p.MandaysEstimation = project.MandaysEstimation;
            p.MandaysEstimationCal = project.MandaysEstimationCal;
            p.Description = project.Description;

            db.SaveChanges();

            return Json(p, JsonRequestBehavior.AllowGet);


        }


        public ActionResult Edit([Bind(Include = "ProjectId,ClientId,ProjectStatusId,ProjectName,Description,PIC,StartDatePlan,EndDatePlan,StartDateActual,EndDateActual,MandaysEstimation,MandaysEstimationCal,CreationBy,CreationDate,ModifiedBy,ModifiedDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            
            return View(project);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}