using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }
    }
}
