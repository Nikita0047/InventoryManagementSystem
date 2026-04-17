using InventoryModels.DTOs;
using InventoryService.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);

            if (warehouse == null)
                return NotFound("Warehouse not found");

            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarehouseDto dto)
        {
            var createdWarehouse = await _warehouseService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdWarehouse.Id },
                createdWarehouse
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WarehouseDto dto)
        {
            var result = await _warehouseService.GetWarehouseByIdAsync(id);
            if (result == null)
                return NotFound("Warehouse not found");
            await _warehouseService.UpdateAsync(id, dto);
            return Ok("Warehouse updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _warehouseService.GetWarehouseByIdAsync(id);
            if (result == null)
                return NotFound("Warehouse not found");
            await _warehouseService.DeleteAsync(id);
            return Ok("Warehouse deleted successfully");
        }
    }
}
