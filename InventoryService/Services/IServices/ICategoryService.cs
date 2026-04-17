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

        Task<CategoryDto> CreateAsync(CategoryDto dto);

        Task UpdateAsync(int id, CategoryDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
