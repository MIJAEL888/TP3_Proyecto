using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    public class SessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session[Constantes.NombreSession.Usuario] == null)
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}