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
    public class ProjectDocumentController : Controller
    {
        private ProjectManagementDbContext db = new ProjectManagementDbContext();

        // GET: ProjectDocument
        public ActionResult Index()
        {
            var projectDocuments = db.ProjectDocuments.Include(p => p.DocumentType).Include(p => p.Project);
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description");
            return View(projectDocuments.ToList());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit([Bind(Include = "DocumentId,ProjectId,DocumentTypeId,DocumentName,FilePath,Version")] ProjectDocument projectDocument, int? id)
        {
            if (id == null)
            {
                if (ModelState.IsValid)
                {
                    db.ProjectDocuments.Add(projectDocument);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", projectDocument.DocumentTypeId);
                ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectDocument.ProjectId);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(projectDocument).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", projectDocument.DocumentTypeId);
                ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectDocument.ProjectId);
                return View(projectDocument);
            }
            return View(projectDocument);
        }


        // GET: ProjectDocument/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDocument projectDocument = db.ProjectDocuments.Find(id);
            if (projectDocument == null)
            {
                return HttpNotFound();
            }
            return View(projectDocument);
        }

        // GET: ProjectDocument/Create
        public ActionResult Create()
        {
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description");
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: ProjectDocument/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentId,ProjectId,DocumentTypeId,DocumentName,FilePath,Version")] ProjectDocument projectDocument)
        {
            if (ModelState.IsValid)
            {
                db.ProjectDocuments.Add(projectDocument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", projectDocument.DocumentTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectDocument.ProjectId);
            return View(projectDocument);
        }

        // GET: ProjectDocument/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDocument projectDocument = db.ProjectDocuments.Find(id);
            if (projectDocument == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", projectDocument.DocumentTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectDocument.ProjectId);
            return View(projectDocument);
        }

        // POST: ProjectDocument/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentId,ProjectId,DocumentTypeId,DocumentName,FilePath,Version")] ProjectDocument projectDocument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectDocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", projectDocument.DocumentTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectDocument.ProjectId);
            return View(projectDocument);
        }

        // GET: ProjectDocument/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDocument projectDocument = db.ProjectDocuments.Find(id);
            if (projectDocument == null)
            {
                return HttpNotFound();
            }
            return View(projectDocument);
        }

        // POST: ProjectDocument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectDocument projectDocument = db.ProjectDocuments.Find(id);
            db.ProjectDocuments.Remove(projectDocument);
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
    }
}
