using AutoMapper;
using EventsApp.Code.App_Config;
using EventsApp.Code.CustomMvcAttributes;
using EventsApp.Code.ViagogoClientUtils;
using EventsApp.ViewModels;
using GogoKit;
using GogoKit.Models.Request;
using GogoKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EventsApp.Controllers.Api
{
    
    public class EventsController : Controller
    {
        private IViagogoClient _viagogoClient;

        public EventsController(IViagogoClient viagogoClient) {
            _viagogoClient = viagogoClient;
        }

        //This Action will accept only GET verb
        //And also has a custom ExceptionHandler to demostrate the ability to build such mechanism
        [HttpGet]
        [CustomErrorHandler]
        [Route("~/api/events/get")]
        // GET: Events
        public async Task<JsonResult> Get() {
            IReadOnlyCollection<Event> response = null;
            List<EventViewModel> events = new List<EventViewModel>();

            EventRequest eventRequest = new EventRequest();
            //this method is to showcase the ability to create extension methods
            //to modify in a clean way our request, at the beginning i added sorting my MinTicketPrice
            //but then i decided to manually mark the cheapest ticket in each country
            eventRequest.SetPagingAndSorting();

            try {
                response = await _viagogoClient.Events.GetAllByCategoryAsync(10813, eventRequest);
                //Use Automapper to map response to our ViewModel
                events = Mapper.Map<IReadOnlyCollection<Event>,List<EventViewModel>>(response);
                //Use Extension method to mark the cheapes ticket by country
                events.MarkCheapestEventByCountry();
                
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(events, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {ErrorMessage=ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void OnAuthorization(AuthorizationContext filterContext) {
            var cookie = filterContext.HttpContext.Request.Cookies[Config.AdeleCookieName];

            //Use of C#6 syntax
            if (cookie?.Value == Config.AdeleCookieValue) {
                base.OnAuthorization(filterContext);
            }
            else {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                filterContext.Result = new JsonResult() { Data = new { ErrorMessage = "UnAuthorizedUser" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

    }
}