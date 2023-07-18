using MabnaDBTest.Domain.DTOs;
using MabnaDBTest.Domain.DTOs.Instrument;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MabnaDBTest.Core.Queries
{
    public class GetAllTradeQuery : IRequest<CustomResponseDto<IEnumerable<GetAllTradeResponse>>>
    {
    }
}
