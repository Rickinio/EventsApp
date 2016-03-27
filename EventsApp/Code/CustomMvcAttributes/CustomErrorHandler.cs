using Autofac.Integration.Mvc;
using EventsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventsApp.Code.CustomMvcAttributes
{
    public class CustomErrorHandler: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext) {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            LogService.Log(ex);

            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            filterContext.Result = new JsonResult() {Data= new { ErrorMessage = ex.Message },JsonRequestBehavior=JsonRequestBehavior.AllowGet};
        }
    }
}