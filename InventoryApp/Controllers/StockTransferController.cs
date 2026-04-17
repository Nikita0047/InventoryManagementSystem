using InventoryModels.DTOs;
using InventoryService.Services.IServices;
using Microsoft.AspNetCore.Mvc;



namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTransferController : ControllerBase
    {
        private readonly IStockTransferService _transferService;

        public StockTransferController(IStockTransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transfers = await _transferService.GetAllTransfersAsync();
            return Ok(transfers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transfer = await _transferService.GetTransferByIdAsync(id);

            if (transfer == null)
                return NotFound("Transfer not found");

            return Ok(transfer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockTransferDto dto)
        {
            var createdTransfer = await _transferService.CreateAsync(dto);

            return Ok(createdTransfer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _transferService.GetTransferByIdAsync(id);
            if (result == null)
                return NotFound("Transfer not found");
            await _transferService.DeleteAsync(id);
            return Ok("Transfer deleted successfully");
        }
    }
}
