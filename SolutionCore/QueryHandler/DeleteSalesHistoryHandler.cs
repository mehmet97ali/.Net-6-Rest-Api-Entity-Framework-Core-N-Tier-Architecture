using Microsoft.EntityFrameworkCore;
using SolutionCore.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.QueryHandler
{
    public class DeleteSalesHistoryHandler
    {
        private readonly ApplicationDbContext _context;
        public DeleteSalesHistoryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> Handle(int productId, int storeId)
        {
            string query = @$"DELETE FROM Sales.InventorySales WHERE [ProductId] = '{productId}' and [StoreId] = '{storeId}'";

            int dbResult = _context.Database.ExecuteSqlRaw(query);

            return Task.FromResult(dbResult);
        }
    }
}
