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
        public ActionResult Detalle_Pedido()
        {
            List<PedidoTableViewModel> lstPedido = null;
            using (DBMini_BandidasEntities db = new DBMini_BandidasEntities())
            {
                lstPedido = (from u in db.DetallePedido
                               join e in db.Pedido
                               on u.numPedido equals e.numPedido
                               join f in db.Producto
                               on u.idProducto equals f.id
                               join g in db.Topping
                               on u.idTopping1  equals g.id
                               join h in db.Topping
                               on u.idTopping2 equals h.id

                             orderby u.id
                               select new PedidoTableViewModel
                               {
                                   id = u.id,
                                   numPedido = u.numPedido,
                                   idProducto = u.idProducto,
                                   cantidad = u.cantidad,
                                   idTopping1 = u.idTopping1,
                                   idTopping2 = u.idTopping2,
                                   Pedido = e,
                                   Producto = f,
                                   Topping1 = g,
                                   Topping2 = h,
                               }).ToList();
            }
            return View(lstPedido);
        }
    }
}