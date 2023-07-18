using MabnaDBTest.Application.UseCases.Instrument.Queries;

using Microsoft.AspNetCore.Mvc;

namespace MabnaDBTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : BaseApiController
    {
        /// <summary>
        /// دریافت اطلاعات آخرین معامله هر نماد
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTradeQuery(_UnitOfWork);
            //await query.Handle(new CancellationToken());
            return OkReult(await _Mediator.Send(query));
        }

    }
}
