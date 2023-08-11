using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

namespace MiniBandidas.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Required, EmailAddress]
        [Display(Name = "Email:")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Nombre:")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido:")]
        public string apellido { get; set; }
        [Required, MinLength(8), MembershipPassword ]
        [Display(Name = "Contraseña:")]
        public string contrasenna { get; set; }
        [Required, Phone]
        [Display(Name = "Telefono:")]
        public string telefono { get; set; }
       /* [Required]
        [Display(Name = "Estado:")]*/
        public string estado { get; set; }
        [Required, MinLength(8)]
        [Display(Name = "Cedula:")]
        public string cedula { get; set; }

       // public IEnumerable<SelectListItem> Estado { get; set; }
    }
}