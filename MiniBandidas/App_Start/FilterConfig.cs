using System.Web;
using System.Web.Mvc;
using MiniBandidas.Filters;

namespace MiniBandidas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificarSesion());    
        }
    }
}
