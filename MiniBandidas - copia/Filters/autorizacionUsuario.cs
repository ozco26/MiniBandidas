using MiniBandidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class autorizacionUsuario : AuthorizeAttribute
    {
        private Usuarios TOUsuario;
        private DBMini_BandidasEntities1 db = new DBMini_BandidasEntities1();
        private int idOperacion ;

        public autorizacionUsuario(int idOperacion = 0) => this.idOperacion = idOperacion;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                TOUsuario = (Usuarios)HttpContext.Current.Session["Usuario"];
                var listMisOperaciones = from m in db.rol_operacion
                                         where m.idRol == TOUsuario.estado
                                         && m.idOperacion == idOperacion
                                         select m;
                if (listMisOperaciones.ToList().Count() == 0 )
                {
                    filterContext.Result = new RedirectResult("~/NoAutorizado/Error/~");
                }
            } catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/NoAutorizado/Error/~");
            }
        }

    }
}