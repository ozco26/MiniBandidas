using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBandidas.Models.TableViewModels
{
    public class PedidoTableViewModel
    {
        public int id { get; set; }
        public int numPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int idTopping1 { get; set; }
        public int idTopping2 { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Topping Topping1 { get; set; }
        public virtual Topping Topping2 { get; set; }
    }
}