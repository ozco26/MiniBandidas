//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniBandidas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallePedido
    {
        public int id { get; set; }
        public int numPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int idTopping1 { get; set; }
        public int idTopping2 { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Topping Topping { get; set; }
        public virtual Topping Topping1 { get; set; }
    }
}
