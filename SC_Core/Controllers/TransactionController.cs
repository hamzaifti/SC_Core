using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SC_Common.Dto;
using SC_Common.Model;
using SC_Service.Transactions;

namespace SC_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetTransactionTypes()
        {
            return Ok(_transactionService.GetTransactionTypes());
        }

        [HttpPost]
        public async Task<IActionResult> SaveTransaction(SaveTransactionDto instance)
        {
            return Ok(await _transactionService.SaveTransaction(instance));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllTransactionsPaged(PagedRequestDto instance)
        {
            return Ok(await _transactionService.GetAllTransactionsPaged(instance));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(long id)
        {
            return Ok(await _transactionService.GetTransactionById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(long id)
        {
            return Ok(await _transactionService.DeleteTransaction(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionByDateRange([FromQuery]DateTime startDate,[FromQuery] DateTime endDate)
        {
            return Ok(await _transactionService.GetTransactionByDateRange(startDate, endDate));
        }

    }
}
