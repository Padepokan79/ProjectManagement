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
    public class ModulController : Controller
    {
        private ProjectManagementDbContext db = new ProjectManagementDbContext();

        // GET: Modul
        public ActionResult Index()
        {
            var moduls = db.Moduls.Include(m => m.Modul2).Include(m => m.ModulStatu).Include(m => m.Project);
            return View(moduls.ToList());
        }

        // GET: Modul/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // GET: Modul/Create
        public ActionResult Create()
        {
            ViewBag.ParentModulId = new SelectList(db.Moduls, "ModulId", "ModulName");
            ViewBag.ModulStatusId = new SelectList(db.ModulStatus, "ModulStatusId", "Description");
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: Modul/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModulId,ParentModulId,ProjectId,ModulStatusId,ModulName,Description,PIC,ModulNumber,MadaysEstimation")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Moduls.Add(modul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentModulId = new SelectList(db.Moduls, "ModulId", "ModulName", modul.ParentModulId);
            ViewBag.ModulStatusId = new SelectList(db.ModulStatus, "ModulStatusId", "Description", modul.ModulStatusId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", modul.ProjectId);
            return View(modul);
        }

        // GET: Modul/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentModulId = new SelectList(db.Moduls, "ModulId", "ModulName", modul.ParentModulId);
            ViewBag.ModulStatusId = new SelectList(db.ModulStatus, "ModulStatusId", "Description", modul.ModulStatusId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", modul.ProjectId);
            return View(modul);
        }

        // POST: Modul/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModulId,ParentModulId,ProjectId,ModulStatusId,ModulName,Description,PIC,ModulNumber,MadaysEstimation")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentModulId = new SelectList(db.Moduls, "ModulId", "ModulName", modul.ParentModulId);
            ViewBag.ModulStatusId = new SelectList(db.ModulStatus, "ModulStatusId", "Description", modul.ModulStatusId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", modul.ProjectId);
            return View(modul);
        }

        // GET: Modul/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Modul/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modul modul = db.Moduls.Find(id);
            db.Moduls.Remove(modul);
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
