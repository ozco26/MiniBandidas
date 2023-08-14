using MiniBandidas.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //[autorizacionUsuario(idOperacion: (1))] Debería de poderse ver el menú aunque no haya iniciado sesión 
        public ActionResult Menu()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Nosotros()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}