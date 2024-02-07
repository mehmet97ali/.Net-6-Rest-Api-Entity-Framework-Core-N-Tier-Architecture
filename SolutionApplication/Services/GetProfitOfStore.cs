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
    public class GetProfitOfStore
    {
        public GetProfitOfStore() { }
        public Task<string> Main(int storeId, ApplicationDbContext context)
        {
            var DbResult = new GetProfitOfStoreHandler(context).Handle(storeId);

            return Task.FromResult(DbResult.Result);
        }
    }
}
