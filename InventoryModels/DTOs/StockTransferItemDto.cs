using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.DTOs
{
    public class StockTransferItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
