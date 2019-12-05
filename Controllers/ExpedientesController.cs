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
            var expedientes = db.Expedientes.Include(p => p.Paciente);
            return View(expedientes);
        }

        // GET: Expedientes/Details/5
        public ActionResult Details(int? id)
        {
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
            ViewBag.PacienteID = id;
            //ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombres");
            return View();
        }

        // POST: Expedientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpedienteID,PacienteID,Aseguradora,NumeroNSS,MotivoIngreso,Antecedentes,Pulso,FrecuenciaCardiaca,PrecionArteriar,FrecuenciaRespiratoria,ExamenPaciente,Diagnostico,Conducta,Evolucion,Recomendacion")] Expediente expediente, int id)
        {
            expediente.PacienteID = id;
            try
            {
                db.Expedientes.Add(expediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ViewBag.PacienteID = id;
            return View(expediente);
        }

        // GET: Expedientes/Edit/5
        public ActionResult Edit(int? id)
        {
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
            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpedienteID,PacienteID,Aseguradora,NumeroNSS,MotivoIngreso,Antecedentes,Pulso,FrecuenciaCardiaca,PrecionArteriar,FrecuenciaRespiratoria,ExamenPaciente,Diagnostico,Conducta,Evolucion,Recomendacion")] Expediente expediente)
        {
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
