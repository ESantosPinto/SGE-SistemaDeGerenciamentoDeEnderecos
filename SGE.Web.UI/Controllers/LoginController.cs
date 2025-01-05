using Microsoft.AspNetCore.Mvc;

namespace SGE.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
