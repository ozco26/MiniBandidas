using Microsoft.Win32;
using MiniBandidas.Filters;
using MiniBandidas.Models;
using MiniBandidas.Models.TableViewModels;
using MiniBandidas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MiniBandidas.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [autorizacionUsuario(idOperacion: (3))]
        public ActionResult Index()
        {
            List<UsuarioTableViewModel> lstUsuarios = null;
            using (DBMini_BandidasEntities db = new DBMini_BandidasEntities())
            {
                lstUsuarios = (from u in db.Usuarios
                               join e in db.Estados
                               on u.estado equals e.id
                               orderby u.id
                               select new UsuarioTableViewModel
                               {
                                   id= u.id,
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

        public ActionResult Registrarse([Bind(Exclude = "estado,id")] UsuarioViewModel model)
        {
            //model.estado = 1; //asigna a la varible estado valor 1 para poder llenenar el valor estado oculto en la vista y que no reviente en

            if (!ModelState.IsValid) return View(model);
            using (var db = new DBMini_BandidasEntities())
            {
               
                Usuarios usuarioTO = new Usuarios();
                usuarioTO.email = model.email;
                usuarioTO.cedula = (model.cedula);
                usuarioTO.nombre = model.nombre;
                usuarioTO.apellido = model.apellido;
                usuarioTO.contrasenna = model.contrasenna;
                usuarioTO.telefono = model.telefono;
                usuarioTO.estado = 1;
                db.Usuarios.Add(usuarioTO);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                }

            }
            return Redirect(Url.Content("~/Login/Index/"));
        }

        [HttpPost]
        [autorizacionUsuario(idOperacion: (3))]
        public ActionResult Delete(int id )
        {
            using (var db = new DBMini_BandidasEntities())
            {
                var usuarioTO = db.Usuarios.Find(id);
                db.Entry(usuarioTO).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return Content("200");
        }

        [HttpGet]
        [autorizacionUsuario(idOperacion: (3))]
        public ActionResult Edit(int id )
        {
            UsuarioViewModel model = new UsuarioViewModel();
            using (var db = new DBMini_BandidasEntities())
            {
                var usuarioTO = db.Usuarios.Find(id);
                var estadosTO = db.Estados;

                model.id = usuarioTO.id;
                model.email = usuarioTO.email;
                model.cedula = usuarioTO.cedula;
                model.nombre = usuarioTO.nombre;
                model.apellido = usuarioTO.apellido;
                model.contrasenna = usuarioTO.contrasenna;
                model.telefono = usuarioTO.telefono;
                model.estado = usuarioTO.estado;

            }
            return View(model);
        }
        [autorizacionUsuario(idOperacion: (3))]
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new DBMini_BandidasEntities())
            {
                var usuarioTO = db.Usuarios.Find(model.id);
                usuarioTO.email = model.email;
                usuarioTO.cedula = model.cedula;
                usuarioTO.nombre = model.nombre;
                usuarioTO.apellido = model.apellido;
                usuarioTO.contrasenna = model.contrasenna;
                usuarioTO.telefono = model.telefono;
                usuarioTO.estado = model.estado;
                db.Entry(usuarioTO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Usuario"));
        }

        
        private IEnumerable<SelectListItem> GetEstadoSelectItem(IEnumerable<Estados> elementos)
        {
            var selectList = new List<SelectListItem>();
            foreach (var elemento in elementos)
            {
                selectList.Add(new SelectListItem
                {
                    Value = elemento.id.ToString(),
                    Text = elemento.id + " | " + elemento.descripcion
                });
            }
            return selectList;
        }
    }
}