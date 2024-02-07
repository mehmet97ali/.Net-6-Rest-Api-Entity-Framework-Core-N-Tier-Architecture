using SolutionApplication.Models;
using SolutionCore.Configuration;
using SolutionCore.QueryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionApplication.Services
{
    public class UpdateSalesHistory
    {
        public UpdateSalesHistory() { }
        public Task<int> Main(SalesHistoryModel request, ApplicationDbContext context)
        {
            int dbResult = new UpdateSalesHistoryHandler(context).Handle(request.ProductId, request.StoreId, request.SalesQuantity, DateTime.Now, request.stock).Result;

            return Task.FromResult(dbResult);
        }
    }
}
