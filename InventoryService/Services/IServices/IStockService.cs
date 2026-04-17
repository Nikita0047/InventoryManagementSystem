using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.IServices
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetAllStocksAsync();

        Task<StockDto?> GetStockByIdAsync(int id);

        Task<StockDto> CreateAsync(StockDto dto);

        Task UpdateAsync(int id, StockDto dto);

        Task DeleteAsync(int id);
    }
}
