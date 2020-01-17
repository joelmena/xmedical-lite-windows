using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XMedicalLite.Models;

namespace XMedicalLite_Windows.Controllers
{
    public class PacientesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Pacientes
        public ActionResult Index()
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View(db.Pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.SexoId = new SelectList(db.Sexos, "SexoID", "Descripcion");
            ViewBag.EstadoCivilId = new SelectList(db.EstadosCivil, "EstadoCivilID", "Descripcion");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            paciente.FechaNacimiento = paciente.FechaNacimiento.Date;
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.SexoId = new SelectList(db.Sexos, "SexoID", "Descripcion", paciente.SexoID);
            ViewBag.EstadoCivilId = new SelectList(db.EstadosCivil, "EstadoCivilID", "Descripcion", paciente.EstadoCivilID);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DatosPaciente(int idPaciente, int idExpediente = 0)
        {
            DateTime fechaCreado = DateTime.Now;
            if(idExpediente != 0)
            {
                fechaCreado = db.Expedientes.Find(idExpediente).CreadoEn;
            }
            ViewBag.fechaCreado = fechaCreado.ToString("G", CultureInfo.CreateSpecificCulture("es-DO"));
            var paciente = db.Pacientes.Find(idPaciente);
            return PartialView("/Views/Shared/_Paciente.cshtml", paciente);
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
