using MiniBandidas.Models;
using MiniBandidas.Models.TableViewModels;
using MiniBandidas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<UsuarioTableViewModel> lstUsuarios = null;
            using (DBMini_BandidasEntities db = new DBMini_BandidasEntities())
            {
                lstUsuarios = (from u in db.Usuarios
                               join e in db.Estados
                               on u.estado equals e.id
                               orderby u.estado
                               select new UsuarioTableViewModel
                               {
                                   email = u.email,
                                   cedula = u.cedula,
                                   nombre = u.nombre,
                                   apellido = u.apellido,
                                   contrasenna = u.contrasenna,
                                   telefono = u.telefono,
                                   estado = u.estado,
                                   Estados = e
                               }).ToList();
            }
            return View(lstUsuarios);
        }
        [HttpGet]
        public ActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrarse(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            using (var db = new DBMini_BandidasEntities())
            {
                Usuarios usuarioTO = new Usuarios();
                usuarioTO.email = model.email;
                usuarioTO.cedula = model.cedula;
                usuarioTO.nombre = model.nombre;
                usuarioTO.apellido = model.apellido;
                usuarioTO.contrasenna = model.contrasenna;
                usuarioTO.telefono = model.telefono;
                usuarioTO.estado = "1";
                db.Usuarios.Add(usuarioTO);
                db.SaveChanges( );
            }


            return Redirect(Url.Content("~/Login/Index/"));
        }

    }
}