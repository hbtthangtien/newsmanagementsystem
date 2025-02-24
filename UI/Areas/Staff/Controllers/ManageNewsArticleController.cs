using Application.DTOs;
using Application.Interface;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UI.Areas.Staff.Models;

namespace UI.Areas.Staff.Controllers
{
    [Area("staff")]
    public class ManageNewsArticleController : Controller
    {
        private readonly INewArticleService _newsArticleService;
        private readonly ICategoryServices _categoryService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public ManageNewsArticleController(INewArticleService newArticleService,
            IMapper mapper,
            ICategoryServices categoryService,
            ITagService tagService)
        {
            _newsArticleService = newArticleService;
            _mapper = mapper;
            _categoryService = categoryService;
            _tagService = tagService;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _newsArticleService.GetAllAsync();
            var articleModel = _mapper.Map<List<NewsArticleModel>>(data);
            return View(articleModel);
        }
        public async Task<IActionResult> Add()
        {
            var db2 = await _categoryService.GetAllCategoryAsync();
            var dataTag = await _tagService.GetAllTags();
            var categories = _mapper.Map<List<CategoryModel>>(db2);
            var tags = _mapper.Map<List<TagModel>>(dataTag);
            ViewBag.Categories = categories;
            ViewBag.Tags = tags;
            return View(new NewsArticleModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(NewsArticleModel model)
        {
            model.CreatedBy = "1";
            var data = _mapper.Map<NewsArticleDTO>(model);
            await _newsArticleService.AddAsync(data);
            return RedirectToAction("index", "ManageNewsArticle");
        }
        public IActionResult Edit()
        {
            return View(new NewsArticleModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await _newsArticleService.DeleteAsync(id);
            return Json(new
            {
                Message = "Delete successfully",
                success = true
            });
        }
    }
}
