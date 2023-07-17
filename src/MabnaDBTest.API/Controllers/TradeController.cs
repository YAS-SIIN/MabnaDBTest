using MabnaDBTest.Application.UseCases.Instrument.Queries;

using Microsoft.AspNetCore.Mvc;

namespace MabnaDBTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] GetAllTradeQuery request)
        {
            return OkReult(await Mediator.Send(request));
        }

    }
}
