using MiniBandidas.Models.TableViewModels;
using MiniBandidas.Models;
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
        public ActionResult MostrarPedido()
        {

            List<PedidoTableViewModel> lstPedido = null;
            using (DBMini_BandidasEntities db = new DBMini_BandidasEntities())
            {
                lstPedido = (from p in db.Pedido
                                orderby p.numPedido
                               select new PedidoTableViewModel
                               {
                                   numPedido = p.numPedido,
                                   subtotal = p.subtotal,
                                   total = p.total,

                               }).ToList();
            }
            return View(lstPedido);

        }

        public ActionResult CrearPedido() 
        {
            
            return View();
        
        }
    }
}