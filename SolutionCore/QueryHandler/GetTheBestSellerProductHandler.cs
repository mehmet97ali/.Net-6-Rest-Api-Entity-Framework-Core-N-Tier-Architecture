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
    public class GetTheBestSellerProductHandler
    {
        private readonly ApplicationDbContext _context;
        public GetTheBestSellerProductHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<string> Handle()
        {
            FormattableString query = FormattableStringFactory.Create("SELECT top 1 ProductName FROM Sales.InventorySales " +
                "JOIN Sales.Products ON Sales.InventorySales.ProductId = Sales.Products.Id " +
                "order by SalesQuantity desc");

            var data = _context.Database.SqlQuery<string>(query).ToList();
            string result = data.Any() ? data[0] : string.Empty;

            return Task.FromResult(result);
        }
    }
}
