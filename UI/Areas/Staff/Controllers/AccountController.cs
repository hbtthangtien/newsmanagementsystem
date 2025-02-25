using Application.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistences.Entities;
using UI.Areas.Staff.Models;
using UI.Filter;

namespace UI.Areas.Staff.Controllers
{
    [Area("staff")]
    [CustomAuthorize("staff")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            string idString = HttpContext.Session.GetString("UserId")!;
            var data = await _accountService.GetAccountByIdAsync(short.Parse(idString));
            var model = _mapper.Map<AccountModel>(data);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountModel model)
        {
            string idString = HttpContext.Session.GetString("UserId")!;
            var account = _mapper.Map<SystemAccount>(model);
            account.AccountId = short.Parse(idString);
            await _accountService.UpdateAccount(account);
            return RedirectToAction("index");
        }
    }
}
