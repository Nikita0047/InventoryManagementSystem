using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.Entity
{
    public class StockTransfer
    {
        public int Id { get; set; }

        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }
        public Warehouse FromWarehouse { get; set; } = null!;
        public Warehouse ToWarehouse { get; set; } = null!;
        public DateTime TransferDate { get; set; }

        public ICollection<StockTransferItem> Items { get; set; } = new List<StockTransferItem>();
    }
}
