using SolutionCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolutionCore.Data_Models;
using System.Runtime.CompilerServices;

namespace SolutionCore.QueryHandler
{
    public class GetSalesHistoryHandler
    {
        private readonly ApplicationDbContext _context;
        public GetSalesHistoryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Handle()
        {
            FormattableString query = FormattableStringFactory.Create("SELECT ProductId,StoreId,SalesQuantity,Stock,ProductName,Cost,SalesPrice,StoreName" +
                                       " FROM Sales.InventorySales " +
                                       "JOIN Sales.Products ON Sales.InventorySales.ProductId = Sales.Products.Id" +
                                       "JOIN Sales.Stores ON Sales.InventorySales.StoreId = Sales.Stores.Id");

            var data = _context.Database.SqlQuery<InventorySalesDataModel>(query).ToList();

            return Task.FromResult(data);
        }
    }
}
