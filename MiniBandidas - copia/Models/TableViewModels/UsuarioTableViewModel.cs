using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBandidas.Models.TableViewModels
{
    public class UsuarioTableViewModel
    {
        public int id { get; set; }
        public string email { get; set; }

        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contrasenna { get; set; }
        public string telefono { get; set; }
        public int estado { get; set; }
        

        public virtual Estados Estados { get; set; }


    }
}