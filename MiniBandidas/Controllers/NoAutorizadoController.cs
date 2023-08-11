using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Controllers
{
    public class NoAutorizadoController : Controller
    {
        // GET: NoAutorizado
        public ActionResult Error()
        {
            return View();
        }
    }
}