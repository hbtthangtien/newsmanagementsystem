
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly INewArticleService _newArticleService;
        public LoginController(INewArticleService newArticleService)
        {
            _newArticleService = newArticleService;
        }

        public IActionResult Index()
        {
            var loginModel = new LoginModel();
            return View(loginModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            return Ok(await _newArticleService.GetAllAsync());
        }
        
    }
}
