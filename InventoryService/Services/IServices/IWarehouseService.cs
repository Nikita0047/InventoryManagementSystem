using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.IServices
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync();

        Task<WarehouseDto?> GetWarehouseByIdAsync(int id);

        Task<WarehouseDto> CreateAsync(WarehouseDto dto);

        Task UpdateAsync(int id, WarehouseDto dto);

        Task DeleteAsync(int id);
    }
}
