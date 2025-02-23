using Application.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewArticleService _newArticleService;
        private readonly IMapper _mapper;
        public HomeController(INewArticleService newArticleService, IMapper mapper)
        {
            _newArticleService = newArticleService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles =await _newArticleService.GetAllAsync();
            var list = _mapper.Map<List<NewsArticleViewModel>>(articles);
            return View(list);
        }
        public async Task<IActionResult> Details(string id)
        {
            var article = await _newArticleService.GetByIdAsync(id);
            return View(_mapper.Map<NewsArticleViewModel>(article));
        }
    }
}
