using ProjectManagement.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.Controllers
{
    public class PopUpController : Controller
    {
        private ProjectManagementDbContext db = new ProjectManagementDbContext();
        // GET: PopUp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PopUpAddProject()
        {
            ViewBag.ProjectStatus = new SelectList(db.ProjectStatus, "ProjectStatusId", "Description");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");

            return View();
       } 

        public JsonResult insert(string txtProjectName, DateTime txtStartDatePlan, string txtDescription,
            DateTime txtEndDatePlan, int status, decimal txtMadaysEstimation, decimal txtMandaysEstCall,
            DateTime CreationDate, DateTime txtStartDateActual, DateTime EndDateActual, string txtPic,
            string txtModifiedBy, DateTime txtModifiedDate, string CreationBy
            ) 
        {
            var result = new jsonmessage();
            try
            {
                Project pro = new Project()
                {
                    //ClientId = clien,
                    CreationBy = CreationBy,
                    EndDateActual = EndDateActual,
                    StartDateActual = txtStartDateActual,
                    CreationDate = CreationDate,
                    Description = txtDescription,
                    StartDatePlan = txtStartDatePlan,
                    EndDatePlan = txtEndDatePlan,
                    MandaysEstimation = txtMadaysEstimation,
                    MandaysEstimationCal = txtMandaysEstCall,
                    ModifiedBy = txtModifiedBy,
                    ProjectName = txtProjectName,
                    ModifiedDate = txtModifiedDate,
                    PIC = txtPic,
                    ProjectStatusId = status,

                };db.Projects.Add(pro);
                db.SaveChanges();
                result.Message = "Berhasil";

            }
            catch (Exception e)
            {
                result.Message = "Permintaan Anda tidak bisa diproses. Coba lagi nanti.";

            }
            ViewBag.ProjectStatus = new SelectList(db.ProjectStatus, "ProjectStatusId", "Description");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");

            return Json(result,JsonRequestBehavior.AllowGet);
            //return RedirectToAction("PopUpAddProject");
        }
    }
}