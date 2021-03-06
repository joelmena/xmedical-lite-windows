﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XMedicalLite.Models;
using XMedicalLite_Windows.Models;
using XMedicalLite_Windows.Tools;

namespace XMedicalLite_Windows.Controllers
{
    public class ReportesController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reporte(int id)
        {
            Reporte reporte = new Reporte();
            reporte.Expediente = db.Expedientes.Find(id);
            reporte.Paciente = db.Pacientes.Find(reporte.Expediente.PacienteID);
            reporte.Empresa = db.Empresas.FirstOrDefault();
            //ViewBag.edad = DateTime.Now.Year - reporte.Paciente.FechaNacimiento.Year;
            ViewBag.edad = new Utility().Age(reporte.Paciente.FechaNacimiento, reporte.Expediente.CreadoEn);
            return View(reporte);
        }

    }
}