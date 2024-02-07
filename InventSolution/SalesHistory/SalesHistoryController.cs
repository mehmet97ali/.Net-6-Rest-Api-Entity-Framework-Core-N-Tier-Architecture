using Microsoft.AspNetCore.Mvc;
using SolutionApplication.Models;
using SolutionApplication.Services;
using SolutionCore.Configuration;
using System.Net;

namespace InventSolution.SalesHistory
{
    [ApiController]
    [Route("SalesHistory")]
    public class SalesHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SalesHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Sales History.
        /// </summary>
        /// <returns>List Of Sales History.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<SalesHistoryModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSalesHistory()
        {
            List<SalesHistoryModel> salesHistories = await new GetSalesHistory().Main(_context);

            return Ok(salesHistories);
        }

        /// <summary>
        /// Add Sales History.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddSalesHistory([FromBody] SalesHistoryModel request)
        {
            int result = await new AddSalesHistory().Main(request, _context);

            return Created(string.Empty, null);
        }

        /// <summary>
        /// Delete Sales History.
        /// </summary>
        /// <param name="productId">Product ID.</param>
        /// <param name="storeId">Store ID.</param>
        [Route("{productId}/SalesHistory/{storeId}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSalesHistory([FromRoute] int productId, [FromRoute] int storeId)
        {
            int result = await new DeleteSalesHistory().Main(productId, storeId, _context);

            return Ok();
        }

        /// <summary>
        /// Update Sales History.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="request">List of plannings.</param>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateSalesHistory([FromBody] SalesHistoryModel request)
        {
            int result = await new UpdateSalesHistory().Main(request, _context);

            return Ok();
        }
    }
}
