using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.IServices
{
    public interface IStockTransferItemService
    {
        Task<IEnumerable<StockTransferItemDto>> GetAllItemsAsync();

        Task<StockTransferItemDto?> GetItemByIdAsync(int id);

        Task<StockTransferItemDto> CreateItemAsync(StockTransferItemDto dto);

        Task UpdateItemAsync(int id, StockTransferItemDto dto);

        Task DeleteItemAsync(int id);
    }
}
