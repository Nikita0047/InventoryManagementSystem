using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        Task<CategoryDto?> GetCategoryByIdAsync(int id);

        Task<CategoryDto> CreateCategoryAsync(CategoryDto dto);

        Task UpdateCategoryAsync(int id, CategoryDto dto);

        Task DeleteCategoryAsync(int id);
    }
}
