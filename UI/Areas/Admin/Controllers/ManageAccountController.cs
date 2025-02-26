using Application.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistences.Entities;
using Persistences.Enum;
using UI.Areas.Admin.Models;

namespace UI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ManageAccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public ManageAccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _accountService.GetAllAccountAsync();
            var accounts = _mapper.Map<List<AccountModel>>(data);
            return View(accounts);
        }

        public async Task<IActionResult> Edit(short id)
        {
            var data = await _accountService.GetAccountByIdAsync(id);
            var model = _mapper.Map<AccountModel>(data);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountModel model, short id, SystemStatus AccoutStatus) 
        {
           var data = _mapper.Map<SystemAccount>(model);
            data.AccountId = id;
            data.AccountStatus = AccoutStatus;
            await _accountService.UpdateAccountAdmin(data);
            return RedirectToAction("index");
        }

        public IActionResult Add()
        {
            return View(new AccountModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AccountModel model)
        {
            var data = _mapper.Map<SystemAccount>(model);
            await _accountService.AddAccountAsync(data);
            return RedirectToAction("index");
        }
    }

}
