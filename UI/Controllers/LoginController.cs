
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var loginModel = new LoginModel();
            return View(loginModel);
        }
        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            return Ok(loginModel);
        }
        
    }
}
