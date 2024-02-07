using Microsoft.EntityFrameworkCore;
using SolutionCore.Configuration;
using SolutionCore.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.QueryHandler
{
    public class GetProfitOfStoreHandler
    {
        private readonly ApplicationDbContext _context;
        public GetProfitOfStoreHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<string> Handle(int storeId)
        {
            FormattableString query = FormattableStringFactory.Create("SELECT " +
                "(SalesQuantity * SalesPrice - SalesQuantity * Cost) as profitable FROM Sales.InventorySales " +
                "JOIN Sales.Products ON Sales.InventorySales.ProductId = Sales.Products.Id " +
                "JOIN Sales.Stores ON Sales.InventorySales.StoreId = Sales.Stores.Id " +
                "where StoreId = {0}", storeId);

            var data = _context.Database.SqlQuery<int>(query).ToList();
            string result = data.Any() ? data[0].ToString() : string.Empty;

            return Task.FromResult(result);
        }
    }
}
