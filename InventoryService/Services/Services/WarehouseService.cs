using InventoryModels.DTOs;
using InventoryModels.Entity;
using InventoryRepository.Repository;
using InventoryService.Services.IServices;

namespace InventoryService.Services.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Warehouse> _warehouseRepo;

        public WarehouseService(IUnitOfWork unitOfWork, IRepository<Warehouse> warehouseRepo)
        {
            _unitOfWork = unitOfWork;
            _warehouseRepo = warehouseRepo;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync()
        {
            var warehouses = await _warehouseRepo.GetAllAsync();

            return warehouses.Select(w => new WarehouseDto
            {
                Id = w.Id,
                Name = w.Name,
                Location = w.Location
            });
        }

        public async Task<WarehouseDto?> GetWarehouseByIdAsync(int id)
        {
            var warehouse = await _warehouseRepo.GetByIdAsync(id);

            if (warehouse == null)
                return null;

            return new WarehouseDto
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Location = warehouse.Location
            };
        }

        public async Task<WarehouseDto> CreateAsync(WarehouseDto dto)
        {
            var warehouse = new Warehouse
            {
                Name = dto.Name,
                Location = dto.Location
            };

            await _warehouseRepo.AddAsync(warehouse);
            await _unitOfWork.SaveAsync();

            dto.Id = warehouse.Id;

            return dto;
        }

        public async Task UpdateAsync(int id, WarehouseDto dto)
        {
            var warehouse = await _warehouseRepo.GetByIdAsync(id);

            if (warehouse == null)
                throw new Exception("Warehouse not found");

            warehouse.Name = dto.Name;
            warehouse.Location = dto.Location;

            _warehouseRepo.Update(warehouse);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var warehouse = await _warehouseRepo.GetByIdAsync(id);

            if (warehouse == null)
                throw new Exception("Warehouse not found");

            _warehouseRepo.Delete(warehouse);

            await _unitOfWork.SaveAsync();
        }
    }
}
