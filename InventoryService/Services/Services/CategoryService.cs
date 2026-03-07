using InventoryModels.DTOs;
using InventoryModels.Entity;
using InventoryService.Repository;
using InventoryService.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IUnitOfWork unitOfWork, Repository<Category> categoryRepo)
        {
            _unitOfWork = unitOfWork;
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
                return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            await _categoryRepo.AddAsync(category);
            await _unitOfWork.SaveAsync();

            dto.Id = category.Id;

            return dto;
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto dto)
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
                throw new Exception("Category not found");

            category.Name = dto.Name;

            _categoryRepo.Update(category);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
                throw new Exception("Category not found");

            _categoryRepo.Delete(category);

            await _unitOfWork.SaveAsync();
        }
    }
}
