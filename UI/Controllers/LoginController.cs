
using Application.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistences.Entities;
using System.Text.Json;
using UI.Models;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;
        public LoginController(IAuthenticateService authenticateService, IMapper mapper)
        {
            _authenticateService = authenticateService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var loginModel = new LoginModel();
            return View(loginModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            var data = new SystemAccount
            {
                AccountPassword = loginModel.Password,
                AccountEmail = loginModel.Email,
            };
            var user = await _authenticateService.LoginUser(data);
            if(user != null)
            {
                var u = new UserModel
                {
                    UserName = user.AccountEmail!,
                    Role = (Persistences.Enum.UserRole)user.AccountRole!
                };
                HttpContext.Session.SetString("user", JsonSerializer.Serialize(u));
                HttpContext.Session.SetString("UserId",user.AccountId+"");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrorMessage"] = "Username or Password is not correct!";
                return View(new LoginModel());

            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }
        
    }
}
