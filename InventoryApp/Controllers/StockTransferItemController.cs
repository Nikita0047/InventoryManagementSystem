
    using InventoryModels.DTOs;
    using InventoryService.Services.IServices;
    using Microsoft.AspNetCore.Mvc;

    namespace InventoryApp.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class StockTransferItemController : ControllerBase
        {
            private readonly IStockTransferItemService _itemService;

            public StockTransferItemController(IStockTransferItemService itemService)
            {
                _itemService = itemService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var items = await _itemService.GetAllItemsAsync();
                return Ok(items);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var item = await _itemService.GetItemByIdAsync(id);

                if (item == null)
                    return NotFound("Item not found");

                return Ok(item);
            }

            [HttpPost]
            public async Task<IActionResult> Create(StockTransferItemDto dto)
            {
                var createdItem = await _itemService.CreateAsync(dto);

                return Ok(createdItem);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, StockTransferItemDto dto)
            {
                var result = await _itemService.GetItemByIdAsync(id);
                if (result == null)
                    return NotFound("Item not found");
                await _itemService.UpdateAsync(id, dto);
                return Ok("Item updated successfully");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _itemService.GetItemByIdAsync(id);
                if (result == null)
                    return NotFound("Item not found");
                await _itemService.DeleteAsync(id);
                return Ok("Item deleted successfully");
            }
        }
    }

