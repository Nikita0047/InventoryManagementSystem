using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.IServices
{
    public interface IStockTransferService
    {
        Task<IEnumerable<StockTransferDto>> GetAllTransfersAsync();

        Task<StockTransferDto?> GetTransferByIdAsync(int id);

        Task<StockTransferDto> CreateTransferAsync(StockTransferDto dto);

        Task DeleteTransferAsync(int id);
    }
}
