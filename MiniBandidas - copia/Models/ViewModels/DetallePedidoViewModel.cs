using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MiniBandidas.Models.ViewModels
{
    public class DetallePedidoViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Numero de pedido:")]
        public int numPedido { get; set; }
        [Required]
        [Display(Name = "ID del producto:")]
        public int idProducto { get; set; }
        [Required]
        [Display(Name = "Cantidad:")]
        public int cantidad { get; set; }
        [Required]
        [Display(Name = "ID del Topping 1 :")]
        public int idTopping1 { get; set; }
        [Required]
        [Display(Name = "ID del Topping 2 :")]
        public int idTopping2 { get; set; }
        [Required]
        [Display(Name = "Pedido :")]

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Topping Topping1 { get; set; }
        public virtual Topping Topping2 { get; set; }

    }
}