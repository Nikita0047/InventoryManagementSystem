using InventoryModels.DTOs;
using InventoryModels.Entity;
using InventoryRepository.Repository;
using InventoryService.Services.IServices;

namespace InventoryService.Services.Services
{
    public class StockTransferService : IStockTransferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<StockTransfer> _transferRepo;
        private readonly IRepository<StockTransferItem> _itemRepo;

        public StockTransferService(
            IUnitOfWork unitOfWork,
            IRepository<StockTransfer> transferRepo,
            IRepository<StockTransferItem> itemRepo)
        {
            _unitOfWork = unitOfWork;
            _transferRepo = transferRepo;
            _itemRepo = itemRepo;
        }

        public async Task<IEnumerable<StockTransferDto>> GetAllTransfersAsync()
        {
            var transfers = await _transferRepo.GetAllAsync();

            return transfers.Select(t => new StockTransferDto
            {
                FromWarehouseId = t.FromWarehouseId,
                ToWarehouseId = t.ToWarehouseId,
                Items = t.Items.Select(i => new StockTransferItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            });
        }

        public async Task<StockTransferDto?> GetTransferByIdAsync(int id)
        {
            var transfer = await _transferRepo.GetByIdAsync(id);

            if (transfer == null)
                return null;

            return new StockTransferDto
            {
                FromWarehouseId = transfer.FromWarehouseId,
                ToWarehouseId = transfer.ToWarehouseId,
                Items = transfer.Items.Select(i => new StockTransferItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
        }

        public async Task<StockTransferDto> CreateTransferAsync(StockTransferDto dto)
        {
            var transfer = new StockTransfer
            {
                FromWarehouseId = dto.FromWarehouseId,
                ToWarehouseId = dto.ToWarehouseId,
                TransferDate = DateTime.UtcNow
            };

            await _transferRepo.AddAsync(transfer);
            await _unitOfWork.SaveAsync();

            foreach (var item in dto.Items)
            {
                var transferItem = new StockTransferItem
                {
                    StockTransferId = transfer.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                await _itemRepo.AddAsync(transferItem);
            }

            await _unitOfWork.SaveAsync();

            return dto;
        }

        public async Task DeleteTransferAsync(int id)
        {
            var transfer = await _transferRepo.GetByIdAsync(id);

            if (transfer == null)
                throw new Exception("Transfer not found");

            _transferRepo.Delete(transfer);

            await _unitOfWork.SaveAsync();
        }
    }
}
