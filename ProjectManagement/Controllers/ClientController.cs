using ProjectManagement.Entites;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.Controllers
{
    public class ClientController : Controller
    {
        ProjectManagementDbContext db = new ProjectManagementDbContext();
        public ActionResult Index()
        {
            //test Commit
            return View();
        }

        public JsonResult Read()
        {
            List<ClientViewModel> GetClientList = db.Clients.Select(x => new ClientViewModel
            {
                ClientId = x.ClientId,
                ContactPerson = x.ContactPerson,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone
            }).ToList();

            return Json(GetClientList, JsonRequestBehavior.AllowGet);
        }
    }
}