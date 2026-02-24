using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.DTOs
{
    public class StockTransferDto
    {
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }

        public List<StockTransferItemDto> Items { get; set; }
    }
}
