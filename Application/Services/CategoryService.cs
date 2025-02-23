using Application.Interface;
using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryrepository _categoryRepository;
        public CategoryService(ICategoryrepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangeAsync();
        }

        public async Task DeleteCategoryById(int id)
        {
            var category =await _categoryRepository.GetBySingleAsync(category => category.CategoryId == id);
            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetBySingleAsync(e => e.CategoryId == id);
        }

        public async Task UpdateCategory(Category category)
        {
            var update =await _categoryRepository.GetBySingleAsync(_category => category.CategoryId == _category.CategoryId);
            update.CategoryDesciption = category.CategoryDesciption;
            update.CategoryName = category.CategoryName;
            update.ParentCategoryId = category.ParentCategoryId;
            _categoryRepository.Update(update);
            await _categoryRepository.SaveChangeAsync();
            await Task.CompletedTask;
        }
    }
}
