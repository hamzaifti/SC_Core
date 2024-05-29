using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SC_Service.IOU;

namespace SC_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class IouController : ControllerBase
    {
        private readonly IIouService _iouService;

        public IouController(IIouService iouService)
        {
            _iouService = iouService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIouReferences()
        {
            return Ok(await _iouService.GetIouReferences());
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetIouReferenceForTransaction(long transactionId)
        {
            return Ok(await _iouService.GetIouReferenceFromTransaction(transactionId));
        }
    }
}
