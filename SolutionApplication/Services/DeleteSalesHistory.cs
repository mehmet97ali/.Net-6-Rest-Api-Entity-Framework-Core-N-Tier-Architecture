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
    public class DeleteSalesHistory
    {
        public DeleteSalesHistory() { }
        public Task<int> Main(int productId, int storeId, ApplicationDbContext context)
        {
            int dbResult = new DeleteSalesHistoryHandler(context).Handle(productId, storeId).Result;

            return Task.FromResult(dbResult);
        }
    }
}
