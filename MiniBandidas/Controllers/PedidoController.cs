using MiniBandidas.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        [autorizacionUsuario(idOperacion: (3))]

        public ActionResult Pedido()
        {
            return View();
        }
    }
}