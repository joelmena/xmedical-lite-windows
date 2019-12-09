using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XMedicalLite.Models;

namespace XMedicalLite_Windows.Controllers
{
    public class ExpedientesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Expedientes
        public ActionResult Index()
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            var expedientes = db.Expedientes.Include(p => p.Paciente);
            return View(expedientes);
        }

        // GET: Expedientes/Details/5
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
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // GET: Expedientes/Create
        public ActionResult Create(int id)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PacienteID = id;
            ViewBag.TriajeID = new SelectList(db.Triajes, "TriajeID", "Color");
            return View();
        }

        // POST: Expedientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expediente expediente, int id)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            expediente.PacienteID = id;
            if (ModelState.IsValid)
            {
                db.Expedientes.Add(expediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PacienteID = id;
            return View(expediente);
        }

        // GET: Expedientes/Edit/5
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
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombres", expediente.PacienteID);
            ViewBag.TriajeID = new SelectList(db.Triajes, "TriajeID", "Color", expediente.TriajeID);
            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expediente expediente)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                db.Entry(expediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombres", expediente.PacienteID);
            return View(expediente);
        }

        // GET: Expedientes/Delete/5
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
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            Expediente expediente = db.Expedientes.Find(id);
            db.Expedientes.Remove(expediente);
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
