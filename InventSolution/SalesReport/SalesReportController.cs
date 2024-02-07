using Microsoft.AspNetCore.Mvc;
using SolutionApplication.Models;
using SolutionApplication.Services;
using SolutionCore.Configuration;
using System.Net;

namespace InventSolution.SalesReport
{
    [ApiController]
    [Route("SalesReport")]
    public class SalesReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SalesReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Profit Of Store.
        /// </summary>
        /// <param name="storeId">Store ID.</param>
        [Route("{storeId}/SalesReport")]
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProfitOfStore([FromRoute] int storeId)
        {
            var result = await new GetProfitOfStore().Main(storeId, _context);

            return Ok(result);
        }

        /// <summary>
        /// Get The Most Profitable Store.
        /// </summary>
        [Route("SalesReport")]
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTheMostProfitableStore()
        {
            var result = await new GetTheMostProfitableStore().Main(_context);

            return Ok(result);
        }

        /// <summary>
        /// Get The Best Seller Product.
        /// </summary>
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTheBestSellerProduct()
        {
            var result = await new GetTheBestSellerProduct().Main(_context);

            return Ok(result);
        }
    }
}
