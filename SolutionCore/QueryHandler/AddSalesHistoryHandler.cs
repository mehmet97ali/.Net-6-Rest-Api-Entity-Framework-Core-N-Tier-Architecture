using Microsoft.EntityFrameworkCore;
using SolutionCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.QueryHandler
{
    public class AddSalesHistoryHandler
    {
        private readonly ApplicationDbContext _context;
        public AddSalesHistoryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> Handle(int productId, int storeId, int salesQuantity, DateTime date, int stock)
        {
            string query = @$"INSERT INTO Sales.InventorySales VALUES ('{productId}','{storeId}', '{date}', '{salesQuantity}', '{stock}')";

            int dbResult = _context.Database.ExecuteSqlRaw(query);

            return Task.FromResult(dbResult);
        }
    }
}
