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
        public ActionResult Procesar_Pedido()
        {
<<<<<<<< HEAD:MiniBandidas/Controllers/DetallePedidoController.cs
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

                return View(lstPedido);
========

            List<PedidoTableViewModel> lstPedidos = null;
            using (DBMini_BandidasEntities1 db = new DBMini_BandidasEntities1())
            {
                lstPedidos = (from p in db.Pedido
                              select new PedidoTableViewModel
                              {
                                  numPedido = p.numPedido,
                                  subtotal = p.subtotal,
                                  total = p.total                              
                                  
                              }).ToList();
                return View(lstPedidos);
            }            
        }

        [HttpPost]
        public ActionResult Crear_registro(PedidoViewModel model)
        {
            using (DBMini_BandidasEntities1 db = new DBMini_BandidasEntities1())
            {

                Pedido pedidoTO= new Pedido();

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

>>>>>>>> pedidos, boton de agregar pedidos registros:MiniBandidas/Controllers/PedidoController.cs
            }
            return Redirect(Url.Content("~/Pedido/Procesar_Pedido/"));
        }
    }


        /*
        //[autorizacionUsuario(idOperacion: (1))]// Debería de poderse ver el menú aunque no haya iniciado sesión 
        public ActionResult Menu()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }*/

    }
