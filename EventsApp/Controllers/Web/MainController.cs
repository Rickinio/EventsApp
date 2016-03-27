using EventsApp.Code.App_Config;
using EventsApp.Code.CustomMvcAttributes;
using System.Web.Mvc;

namespace EventsApp.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index() {
            //I add a cookie HTTP POST ONLY just to demonstrate in EventsController a Custom OnAuthorization
            //I'll check if this cookie with the specific value exists and only then i'll grand access
            Response.Cookies.Add(new System.Web.HttpCookie(Config.AdeleCookieName, Config.AdeleCookieValue) {
                Path = "/",
                HttpOnly = true
            });

            return View();
        }

        public ActionResult Error() {
            return View();
        }
    }
}