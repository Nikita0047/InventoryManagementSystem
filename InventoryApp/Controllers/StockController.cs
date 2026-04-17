using InventoryModels.DTOs;
using InventoryService.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllStocksAsync();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _stockService.GetStockByIdAsync(id);

            if (stock == null)
                return NotFound("Stock not found");

            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockDto dto)
        {
            var createdStock = await _stockService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdStock.Id },
                createdStock
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StockDto dto)
        {
            var result = await _stockService.GetStockByIdAsync(id);
            if (result == null)
                return NotFound("Stock not found");
            await _stockService.UpdateAsync(id, dto);
            return Ok("Stock updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _stockService.GetStockByIdAsync(id);
            if (result == null)
                return NotFound("Stock not found");
            await _stockService.DeleteAsync(id);
            return Ok("Stock deleted successfully");
        }
    }
}
