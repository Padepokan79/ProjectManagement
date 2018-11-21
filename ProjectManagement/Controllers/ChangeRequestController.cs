using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Entites;

namespace ProjectManagement.Controllers
{
    public class ChangeRequestController : Controller
    {
        private ProjectManagementDbContext db = new ProjectManagementDbContext();

        // GET: ChangeRequests
        public ActionResult Index()
        {
            var changeRequests = db.ChangeRequests.Include(c => c.Requirement);
            return View(changeRequests.ToList());
        }

        // GET: ChangeRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeRequest changeRequest = db.ChangeRequests.Find(id);
            if (changeRequest == null)
            {
                return HttpNotFound();
            }
            return View(changeRequest);
        }

        // GET: ChangeRequests/Create
        public ActionResult Create()
        {
            ViewBag.RequimentId = new SelectList(db.Requirements, "RequimentId", "RequirementNumber");
            return View();
        }

        // POST: ChangeRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChangeRequestId,RequimentId,ChangeRequestNumber,Description,ChangeRequestDate,MandaysEstimation")] ChangeRequest changeRequest)
        {
            if (ModelState.IsValid)
            {
                db.ChangeRequests.Add(changeRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequimentId = new SelectList(db.Requirements, "RequimentId", "RequirementNumber", changeRequest.RequimentId);
            return View(changeRequest);
        }

        // GET: ChangeRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeRequest changeRequest = db.ChangeRequests.Find(id);
            if (changeRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequimentId = new SelectList(db.Requirements, "RequimentId", "RequirementNumber", changeRequest.RequimentId);
            return View(changeRequest);
        }

        // POST: ChangeRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChangeRequestId,RequimentId,ChangeRequestNumber,Description,ChangeRequestDate,MandaysEstimation")] ChangeRequest changeRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changeRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequimentId = new SelectList(db.Requirements, "RequimentId", "RequirementNumber", changeRequest.RequimentId);
            return View(changeRequest);
        }

        // GET: ChangeRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeRequest changeRequest = db.ChangeRequests.Find(id);
            if (changeRequest == null)
            {
                return HttpNotFound();
            }
            return View(changeRequest);
        }

        // POST: ChangeRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChangeRequest changeRequest = db.ChangeRequests.Find(id);
            db.ChangeRequests.Remove(changeRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult CreateAndUpdate(int ChangeRequestId,int RequirementId, string ChangeRequestNumber, string Description, decimal MandaysEstimation)
        {
            var result = new jsonMessage();
            try
            {
                ChangeRequest changeRe = new ChangeRequest();

                changeRe.ChangeRequestId = ChangeRequestId;
                changeRe.RequimentId = RequirementId;
                changeRe.ChangeRequestNumber = ChangeRequestNumber;
                changeRe.Description = Description;
                changeRe.MandaysEstimation = MandaysEstimation;

                if (ChangeRequestId == 0)
                {
                    db.ChangeRequests.Add(changeRe);
                    result.Message = "Tambah Berhasil";
                    result.Status = true;
                }
                else
                {
                    db.Entry(changeRe).State = EntityState.Modified;
                    result.Message = "Update Berhasil";
                    result.Status = true;
                }


                db.SaveChanges();
            }
            catch (Exception)
            {

                result.Message = "We are unable to process your request at this time. Please try again later.";
                result.Status = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChangeRequest()
        {

            List<ChangeRequest> _list = new List<ChangeRequest>();

            try
            {
                _list = db.ChangeRequests.ToList();
                var result = from c in _list
                             select new[]
                             {
                          Convert.ToString( c.ChangeRequestId),   
                          Convert.ToString( c.RequimentId ),      
                          Convert.ToString( c.ChangeRequestNumber ),  
                          Convert.ToString( c.Description ), 
                          Convert.ToString( c.MandaysEstimation ), 
                                                   };

                return Json(new
                {
                    aaData = result
                }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception)
            {

                return Json(new
                {
                    aaData = new List<string[]> { }
                }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult Delete(int id)
        {
            var result = new jsonMessage();
            try
            {
                var change = new ChangeRequest() { ChangeRequestId = id };
                db.Entry(change).State = EntityState.Deleted;
                db.SaveChanges();

                result.Message = "Hapus Berhasil";
                result.Status = true;
            }
            catch (Exception)
            {

                result.Message = "We are unable to process your request at this time. Please try again later.";
                result.Status = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}
