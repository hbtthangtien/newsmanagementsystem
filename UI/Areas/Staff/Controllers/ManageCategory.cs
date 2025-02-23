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
    public class ManageCategory : Controller
    {
        private readonly ICategoryServices _categoryService;
        private readonly IMapper _mapper;
        public ManageCategory(ICategoryServices categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var db = await _categoryService.GetAllCategoryAsync();
            var categories = _mapper.Map<List<CategoryModel>>(db);
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryById(id);
            return Json(new
            {
                Message = "Delete successfully",
                success = true
            });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var db = await _categoryService.GetCategoryById(id);
            var category = _mapper.Map<CategoryModel>(db);
            var db2 = await _categoryService.GetAllCategoryAsync();
            var categories = _mapper.Map<List<CategoryModel>>(db2);
            ViewBag.Categories = categories;
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryModel category)
        {
            var _category = _mapper.Map<Category>(category);
            _category.CategoryId = (short)id;
            await _categoryService.UpdateCategory(_category);
            return RedirectToAction("Index", "ManageCategory");
        }

        public async Task<IActionResult> AddAsync()
        {
            var db2 = await _categoryService.GetAllCategoryAsync();
            var categories = _mapper.Map<List<CategoryModel>>(db2);
            ViewBag.Categories = categories;
            return View(new CategoryModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);
            await _categoryService.AddCategoryAsync(category);
            return RedirectToAction("Index", "ManageCategory");
        }
    }
}
