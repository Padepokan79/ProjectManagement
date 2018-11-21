using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProjectManagement.Entites;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectManagementDbContext db = new ProjectManagementDbContext();

        // GET: Projects
        public ActionResult Index(int? page = null)
        {

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");
            ViewBag.ProjectStatusId = new SelectList(db.ProjectStatus, "ProjectStatusId", "Description");
            ViewBag.ProjectEntity = new Project();

            //var project = db.Projects.Include(p => p.Client).Include(p => p.ProjectStatu).OrderBy(s => s.ProjectId);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return View(project.ToPagedList(pageNumber, pageSize));
            //return View(project.ToList());

            return View();
        }

        public JsonResult ListDataProject(int? page = null)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var project = db.Projects
                .Include(p => p.Client)
                .Include(p => p.ProjectStatu)
                .OrderBy(s => s.ProjectId)
                .Select(p => new ProjectViewModel()
                {
                    ProjectId = p.ProjectId,
                    ClientId = p.ClientId,
                    ProjectStatusId = p.ProjectStatusId,
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    PIC = p.PIC,
                    MandaysEstimation = p.MandaysEstimation,
                    MandaysEstimationCal = p.MandaysEstimationCal,
                    CreationBy = p.CreationBy,
                    CreationDate = p.CreationDate,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedDate = p.ModifiedDate,
                    ClientName = p.Client.Name,
                    ProjectStatusName = p.ProjectStatu.Description,
                    StartDatePlanStr = p.StartDatePlan.ToString(),
                    EndDatePlanStr = p.EndDatePlan.ToString(),
                    StartDateActualStr = p.StartDateActual.ToString(),
                    EndDateActualStr = p.EndDateActual.ToString()
                }).ToPagedList(pageNumber, pageSize);

            return Json(project, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Search(ProjectViewModel valueSearch)
        {
            int pageSize = 10;
            int pageNumber = 1;
            var project = db.Projects
                .Include(p => p.Client)
                .Include(p => p.ProjectStatu)
                .OrderBy(s => s.ProjectId)
                .Select(p => new ProjectViewModel()
                {
                    ProjectId = p.ProjectId,
                    ClientId = p.ClientId,
                    ProjectStatusId = p.ProjectStatusId,
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    PIC = p.PIC,
                    MandaysEstimation = p.MandaysEstimation,
                    MandaysEstimationCal = p.MandaysEstimationCal,
                    CreationBy = p.CreationBy,
                    CreationDate = p.CreationDate,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedDate = p.ModifiedDate,
                    ClientName = p.Client.Name,
                    ProjectStatusName = p.ProjectStatu.Description,
                    StartDatePlanStr = p.StartDatePlan.ToString(),
                    EndDatePlanStr = p.EndDatePlan.ToString(),
                    StartDateActualStr = p.StartDateActual.ToString(),
                    EndDateActualStr = p.EndDateActual.ToString()
                });
            if (!(string.IsNullOrEmpty(valueSearch.ProjectName)))
            {
                project = project.Where(d => d.ProjectName.ToLower().Contains(valueSearch.ProjectName.ToLower())).OrderBy(s => s.ProjectId);
            }
            if (valueSearch.FromDatePlan != null && valueSearch.ToDatePlan != null)
            {
                DateTime FromDatePlan = DateTime.Parse(valueSearch.FromDatePlan);
                DateTime ToDatePlan = DateTime.Parse(valueSearch.ToDatePlan);

                project = project.Where(d => d.StartDatePlan >= FromDatePlan && d.StartDatePlan <= ToDatePlan).OrderBy(s => s.ProjectId);
            }
            if (valueSearch.FromDateActual != null && valueSearch.ToDateActual != null)
            {
                DateTime FromDateActual = DateTime.Parse(valueSearch.FromDateActual);
                DateTime ToDateActual = DateTime.Parse(valueSearch.ToDateActual);

                project = project.Where(d => d.StartDateActual >= FromDateActual && d.StartDateActual <= ToDateActual).OrderBy(s => s.ProjectId);
            }
            if (valueSearch.EndToDatePlan != null && valueSearch.EndFromDatePlan != null)
            {
                DateTime EndFromDatePlan = DateTime.Parse(valueSearch.EndFromDatePlan);
                DateTime EndToDatePlan = DateTime.Parse(valueSearch.EndToDatePlan);

                project = project.Where(d => d.EndDatePlan >= EndFromDatePlan && d.EndDatePlan <= EndToDatePlan).OrderBy(s => s.ProjectId);
            }
            if (valueSearch.EndToDateActual != null && valueSearch.EndFromDateActual != null)
            {
                DateTime EndFromDateActual = DateTime.Parse(valueSearch.EndFromDateActual);
                DateTime EndToDateActual = DateTime.Parse(valueSearch.EndToDateActual);
                project = project.Where(d => d.EndDateActual >= EndFromDateActual && d.EndDateActual <= EndToDateActual).OrderBy(s => s.ProjectId);
            }
            if (!(string.IsNullOrEmpty(valueSearch.PIC)))
            {
                project = project.Where(d => d.PIC.ToLower().Contains(valueSearch.PIC.ToLower())).OrderBy(s => s.ProjectId);
            }
            if (valueSearch.ProjectStatusId != null)
            {
                project = project.Where(d => d.ProjectStatusId == valueSearch.ProjectStatusId).OrderBy(s => s.ProjectId);
            }
            if (valueSearch.ClientId != null)
            {
                project = project.Where(d => d.ClientId == valueSearch.ClientId).OrderBy(s => s.ProjectId);
            }



            return Json(project.ToPagedList(pageNumber, pageSize), JsonRequestBehavior.AllowGet);

        }
        // GET: Projects/Details/5


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
