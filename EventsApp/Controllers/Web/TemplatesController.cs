using System.Web.Mvc;

namespace EventsApp.Controllers
{
    public class TemplatesController : Controller
    {
        // GET: Template
        [Route("~/templates/{*name}")]
        public PartialViewResult GetTemplate(string name) {
            return PartialView(name);
        }
    }
}