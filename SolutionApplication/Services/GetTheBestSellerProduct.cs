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
    public class GetTheBestSellerProduct
    {
        public GetTheBestSellerProduct() { }
        public Task<string> Main(ApplicationDbContext context)
        {
            var DbResult = new GetTheBestSellerProductHandler(context).Handle();

            return Task.FromResult(DbResult.Result);
        }
    }
}
