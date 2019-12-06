using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using XMedicalLite.Models;
using System.Web.SessionState;

namespace XMedicalLite_Windows.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = db.Usuarios.Where(u => u.NombreUsuario == usuario.NombreUsuario).FirstOrDefault();
                if(user != null && Crypto.VerifyHashedPassword(user.Password, usuario.Password))
                {
                    HttpContext.Session.Add("userID", user.UsuarioID);
                    HttpContext.Session.Add("userName", user.NombreUsuario);
                    HttpContext.Session.Add("password", user.Password);
                    HttpContext.Session.Add("nombre", user.Nombre + " " + user.Apellido);
                    
                    return RedirectToAction("Index", "Pacientes");
                }
                return RedirectToAction("index", "Pacientes");
            }
            return View();
        }
    }
}