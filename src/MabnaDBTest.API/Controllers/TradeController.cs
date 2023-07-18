
using MabnaDBTest.Core.Commands.Employee;
using MabnaDBTest.Core.Queries;

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
            var query = new GetAllTradeQuery();
            return OkReult(await _Mediator.Send(query));
        }

        /// <summary>
        /// ثبت معامله جدید
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(CreateTradeCommand model)
        { 
            return OkReult(await _Mediator.Send(model));
        }

    }
}
