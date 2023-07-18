
using MabnaDBTest.Domain.DTOs;

using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  MabnaDBTest.Core.Commands.Employee;

public class CreateTradeCommand : IRequest<CustomResponseDto<int>>
{
    public int InstrumentId { get; set; }
    public DateTime DateEn { get; set; }
    public Decimal Open { get; set; }
    public Decimal High { get; set; }
    public Decimal Low { get; set; }
    public Decimal Close { get; set; }
}

