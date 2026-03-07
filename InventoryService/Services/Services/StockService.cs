using InventoryModels.DTOs;
using InventoryModels.Entity;
using InventoryRepository.Repository;
using InventoryService.Services.IServices;


namespace InventoryService.Services.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Stock> _stockRepo;

        public StockService(IUnitOfWork unitOfWork, IRepository<Stock> stockRepo)
        {
            _unitOfWork = unitOfWork;
            _stockRepo = stockRepo;
        }

        public async Task<IEnumerable<StockDto>> GetAllStocksAsync()
        {
            var stocks = await _stockRepo.GetAllAsync();

            return stocks.Select(s => new StockDto
            {
                Id = s.Id,
                ProductId = s.ProductId,
                WarehouseId = s.WarehouseId,
                Quantity = s.Quantity
            });
        }

        public async Task<StockDto?> GetStockByIdAsync(int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
                return null;

            return new StockDto
            {
                Id = stock.Id,
                ProductId = stock.ProductId,
                WarehouseId = stock.WarehouseId,
                Quantity = stock.Quantity
            };
        }

        public async Task<StockDto> CreateStockAsync(StockDto dto)
        {
            var stock = new Stock
            {
                ProductId = dto.ProductId,
                WarehouseId = dto.WarehouseId,
                Quantity = dto.Quantity
            };

            await _stockRepo.AddAsync(stock);
            await _unitOfWork.SaveAsync();

            dto.Id = stock.Id;

            return dto;
        }

        public async Task UpdateStockAsync(int id, StockDto dto)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
                throw new Exception("Stock not found");

            stock.ProductId = dto.ProductId;
            stock.WarehouseId = dto.WarehouseId;
            stock.Quantity = dto.Quantity;

            _stockRepo.Update(stock);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteStockAsync(int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
                throw new Exception("Stock not found");

            _stockRepo.Delete(stock);

            await _unitOfWork.SaveAsync();
        }
    }
}
