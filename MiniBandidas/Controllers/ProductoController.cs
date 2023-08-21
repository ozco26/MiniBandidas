/*using MiniBandidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Controllers
{
   public class ProductoController : Controller
   {

       private readonly DBMini_BandidasEntities _dbContext;


       public ProductoController(DBMini_BandidasEntities dbContext) { _dbContext = dbContext; }

       [HttpPost]

       public ActionResult ProcesarArrays(string[] nomProducto, int[] cantidad)
       {
           for (int i = 0; i < nomProducto.Length; i++)

           {
               string caracteristica = nomProducto[i];

               int cantidades = cantidad[i];


               // Crear un nuevo Producto con los valores de los arrays

               Producto nuevoProducto = new Producto

               {

                   nomProducto = caracteristica,

                   cantidad = cantidad

               };


               // Agregar el nuevo Producto al contexto de base de datos

               _dbContext.Productos.Add(nuevoProducto);

           }


           // Guardar los cambios en la base de datos

           _dbContext.SaveChanges();


           // Puedes redirigir a otra vista o retornar algún resultado

           return View();

       }

   }
}*/