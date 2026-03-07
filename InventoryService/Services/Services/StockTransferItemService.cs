using InventoryModels.DTOs;
using InventoryModels.Entity;
using InventoryRepository.Repository;
using InventoryService.Services.IServices;

namespace InventoryService.Services.Services
{
    public class StockTransferItemService : IStockTransferItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<StockTransferItem> _itemRepo;

        public StockTransferItemService(IUnitOfWork unitOfWork, IRepository<StockTransferItem> itemRepo)
        {
            _unitOfWork = unitOfWork;
            _itemRepo = itemRepo;
        }

        public async Task<IEnumerable<StockTransferItemDto>> GetAllItemsAsync()
        {
            var items = await _itemRepo.GetAllAsync();

            return items.Select(i => new StockTransferItemDto
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            });
        }

        public async Task<StockTransferItemDto?> GetItemByIdAsync(int id)
        {
            var item = await _itemRepo.GetByIdAsync(id);

            if (item == null)
                return null;

            return new StockTransferItemDto
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }

        public async Task<StockTransferItemDto> CreateItemAsync(StockTransferItemDto dto)
        {
            var item = new StockTransferItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            await _itemRepo.AddAsync(item);

            await _unitOfWork.SaveAsync();

            return dto;
        }

        public async Task UpdateItemAsync(int id, StockTransferItemDto dto)
        {
            var item = await _itemRepo.GetByIdAsync(id);

            if (item == null)
                throw new Exception("Item not found");

            item.ProductId = dto.ProductId;
            item.Quantity = dto.Quantity;

            _itemRepo.Update(item);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _itemRepo.GetByIdAsync(id);

            if (item == null)
                throw new Exception("Item not found");

            _itemRepo.Delete(item);

            await _unitOfWork.SaveAsync();
        }
    }
}
