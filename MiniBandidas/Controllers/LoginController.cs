using MiniBandidas.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string txtUsuario, string txtPassword)
        {

            try
            {
                using (var db = new DBMini_BandidasEntities())
                {
                    var lst = from d in db.Usuarios
                              where d.email == txtUsuario && d.contrasenna == txtPassword
                              select d;

                    if (lst.Count() > 0)
                    {
                        Usuarios usuarioTO = lst.First();
                        if (usuarioTO.estado == "Activo")
                        {
                            Session["Usuario"] = usuarioTO;
                            ViewBag.UserSession = $"{usuarioTO.email}";
                            return Content("200");
                        }
                        else
                        {
                            return Content("Usuario inactivo. Contacte al administrador");
                        }
                    }
                    else
                    {
                        return Content("Usuario invalido. Pruebe de nuevo");

                    }
                }




            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error. Detalle: " + ex.Message);

            }





        }
    }
}