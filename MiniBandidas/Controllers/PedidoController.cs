using MiniBandidas.Models.TableViewModels;
using MiniBandidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniBandidas.Models.ViewModels;
using System.Data.Entity.Validation;
using System.Diagnostics;

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
       
        [HttpPost]
        public ActionResult Crear_registro(PedidoViewModel model)
        {
            using (var db = new DBMini_BandidasEntities())
            {
                Pedido pedidoTO = new Pedido();
                var ultimoRegistro = db.Pedido.OrderByDescending(r => r.numPedido).FirstOrDefault();
                if (ultimoRegistro != null)
                {
                    pedidoTO.numPedido = ultimoRegistro.numPedido + 1; // Asigna el siguiente número de pedido
                }
                else
                {
                    pedidoTO.numPedido = 1; // Si no hay registros anteriores, empieza desde 1
                }
                
                pedidoTO.subtotal = 0;
                pedidoTO.total = 0;

                db.Pedido.Add(pedidoTO);
                try
                {
                    db.SaveChanges();
                  //  return RedirectToAction("AgregarDetalle", new { pedidoTO.numPedido });
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
            return Redirect(Url.Content("~/Pedido/MostrarPedido/")); /****aca se redirige a menu o a carrito de compras FALTA HACER*****/
        }
        /*
        public ActionResult AgregarDetalle(DetallePedido model, int numeroPedido)
        {
            Pedido pedido = new .Pedidos.FirstOrDefault(p => p.Id == pedidoId);
            if (pedido == null)
            {
                return NotFound();
            }

            return View();
        }*/
    }
}
        