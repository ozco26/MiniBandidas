using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBandidas.Models.TableViewModels
{
    public class PedidoTableViewModel
    {
        public int numPedido { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }

        public virtual DetallePedido DetallePedido { get; set; }
    }
}