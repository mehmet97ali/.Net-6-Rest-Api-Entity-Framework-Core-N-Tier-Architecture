using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionApplication.Models
{
    public class SalesHistoryModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public int SalesQuantity { get; set; }
        public int stock { get; set; }
    }
}
