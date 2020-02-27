using ProyectoDivisasTomasDominikDadal.LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDivisasTomasDominikDadal.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            ILog log = new Log();
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            log.EscribirLog(filterContext.Exception.Message);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.aspx"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}
