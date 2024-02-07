using Microsoft.EntityFrameworkCore;
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
    public class GetSalesHistory
    {
        public GetSalesHistory() { }

        public Task<List<SalesHistoryModel>> Main(ApplicationDbContext context)
        {
            var DbResult = new GetSalesHistoryHandler(context).Handle();
            
            List<SalesHistoryModel> result = new List<SalesHistoryModel>();

            return Task.FromResult(result);
        }
    }
}
