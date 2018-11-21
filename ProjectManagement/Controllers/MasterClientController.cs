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
    public class MasterClientController : Controller
    {
        private ProjectManagementDbContext db = new ProjectManagementDbContext();
        



        public JsonResult SaveAndUpdateClient(int PID, string namaClient, string contactPerson, string phone, string email)
        {
            var result = new jsonMessage();
            try
            {
                //define the model  
                Client newClient = new Client();
                newClient.ClientId = PID;
                newClient.Name = namaClient;
                newClient.ContactPerson = contactPerson;
                newClient.Phone = phone;
                newClient.Email = email;

                //for insert recored..  
                if (PID == 0)
                {
                    db.Clients.Add(newClient);
                    result.Message = "Data Client berhasil disimpan...";
                    result.Status = true;
                }
                else  //for update recored..  
                {
                    db.Entry(newClient).State = EntityState.Modified;
                    result.Message = "Data Client berhasil diubah...";
                    result.Status = true;
                }
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                //ErrorLogers.ErrorLog(ex);
                result.Message = "Permintaan Anda tidak bisa diproses. Coba lagi nanti.";
                result.Status = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetClient()
        {

            List<Client> _list = new List<Client>();

            try
            {
                _list = db.Clients.ToList();
                var result = from c in _list
                             select new[]
                             {
                          Convert.ToString( c.ClientId ),  // 0     
                          Convert.ToString( c.Name ),  // 1     
                          Convert.ToString( c.ContactPerson ),  // 2     
                          Convert.ToString( c.Phone ),  // 3     
                          Convert.ToString( c.Email )  // 3     
                                                   };

                return Json(new
                {
                    aaData = result
                }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                //ErrorLogers.ErrorLog(ex);
                return Json(new
                {
                    aaData = new List<string[]> { }
                }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult DeleteClient(int id)
        {
            var result = new jsonMessage();
            try
            {

                var client = new Client { ClientId = id };
                db.Entry(client).State = EntityState.Deleted;
                db.SaveChanges();


                result.Message = "Data Client berhasil dihapus...";
                result.Status = true;

            }
            catch (Exception ex)
            {
                //ErrorLogers.ErrorLog(ex);
                result.Message = "Permintaan Anda tidak bisa diproses. Coba lagi nanti.";
                result.Status = false;
                    //commit
            }
            return Json(result, JsonRequestBehavior.AllowGet);   
        }
          

        //sccsc  






        //____________________________________________________________________________________________
        public JsonResult SaveProjectSchedule(int ProjectId, string Version, string StartDate, string EndDate, string CreatedDate, string CreatedBy)
        {
            var result = new jsonMessage();
            try
            {
                //define the model  
                ProjectSchedule newProjectSchedule = new ProjectSchedule();
                newProjectSchedule.ProjectId = ProjectId;
                newProjectSchedule.Version = Version;
                newProjectSchedule.StartDate = Convert.ToDateTime(StartDate);
                newProjectSchedule.EndDate = Convert.ToDateTime(EndDate);
                newProjectSchedule.CreatedDate = Convert.ToDateTime(CreatedDate);
                newProjectSchedule.CreatedBy = CreatedBy;
                newProjectSchedule.IsActive = true;

                

                //for insert recored..  
                db.ProjectSchedules.Add(newProjectSchedule);
                result.Message = "Data Schedule Project berhasil disimpan...";
                result.Status = true;
                
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                //ErrorLogers.ErrorLog(ex);
                result.Message = "Permintaan Anda tidak bisa diproses. Coba lagi nanti.";
                result.Status = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //____________________________________________________________________________________________





        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Name,ContactPerson,Phone,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,ContactPerson,Phone,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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