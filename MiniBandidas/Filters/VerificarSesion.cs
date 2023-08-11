using MiniBandidas.Controllers;
using MiniBandidas.Models;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace MiniBandidas.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            /*
            var usuarioTo = HttpContext.Current.Session["Usuario"];
            if (usuarioTo == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                     
                    //filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    //filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);*/
        }
       


    }
}