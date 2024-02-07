using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.Data_Models
{
    public class InventorySalesDataModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public int SalesQuantity { get; set; }
        public int Stock { get; set; }
        public double SalesPrice { get; set; }
        public double Cost { get; set; }
    }
}
