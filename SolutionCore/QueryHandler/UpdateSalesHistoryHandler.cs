using Microsoft.EntityFrameworkCore;
using SolutionCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.QueryHandler
{
    public class UpdateSalesHistoryHandler
    {
        private readonly ApplicationDbContext _context;
        public UpdateSalesHistoryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> Handle(int productId, int storeId, int salesQuantity, DateTime date, int stock)
        {
            string query = @$"UPDATE Sales.InventorySales SET [SalesQuantity] = '{salesQuantity}', [Stock] = '{stock}', [CreatedDate] = '{date}' WHERE [ProductId] = '{productId}' and [StoreId] = '{storeId}'";

            int dbResult = _context.Database.ExecuteSqlRaw(query);

            return Task.FromResult(dbResult);
        }
    }
}
