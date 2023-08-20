using MiniBandidas.Models.TableViewModels;
using MiniBandidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Diagnostics;
using MiniBandidas.Models.ViewModels;

namespace MiniBandidas.Controllers
{
    public class DetallePedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Detalle_Pedido()
        {
            List<DetallePedidoTableViewModel> lstPedido = null;
            using (DBMini_BandidasEntities db = new DBMini_BandidasEntities())
            {
                lstPedido = (from u in db.DetallePedido
                             join e in db.Pedido
                             on u.numPedido equals e.numPedido
                             join f in db.Producto
                             on u.idProducto equals f.id
                             join g in db.Topping
                             on u.idTopping1 equals g.id
                             join h in db.Topping
                             on u.idTopping2 equals h.id

                             orderby u.id
                             select new DetallePedidoTableViewModel
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


        public ActionResult crearPedido()
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
            return Redirect(Url.Content("~/Pedido/MostrarPedido"));
        }


        public ActionResult crearlinea(DetallePedido model, int numeroPedido)
        {
            if (!ModelState.IsValid) return View();
            using (var db = new DBMini_BandidasEntities())
            {

                /*

               // using (var db = new DBMini_BandidasEntities())
               // {
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
                    ultimoPedido = pedidoTO.numPedido;
                    pedidoTO.subtotal = 0;
                    pedidoTO.total = 0;

                    db.Pedido.Add(pedidoTO);
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
                return Redirect(Url.Content("~/Pedido/MostrarPedido"));
            }
          */


                DetallePedido detallePedidoTO = new DetallePedido();

        detallePedidoTO = numeroPedido; /****/
                detallePedidoTO.idProducto = model.idProducto;
                detallePedidoTO.cantidad = model.cantidad;
                detallePedidoTO.idTopping1 = model.idTopping1;
                detallePedidoTO.idTopping2 = model.idTopping2;
                db.DetallePedido.Add(detallePedidoTO);
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
                return ;
            }
        }
    }
}