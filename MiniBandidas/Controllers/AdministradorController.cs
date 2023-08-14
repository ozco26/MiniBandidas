using MiniBandidas.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        [autorizacionUsuario(idOperacion: 3)]
        public ActionResult Index()
        {
            return View();
        }
    }
}