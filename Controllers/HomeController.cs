using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XMedicalLite.Models;

namespace XMedicalLite_Windows.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Home
        public ActionResult Index(int id)
        {
            var paciente = db.Pacientes.Find(id);
            return PartialView("/Views/Shared/_Paciente.cshtml", paciente);
        }
    }
}