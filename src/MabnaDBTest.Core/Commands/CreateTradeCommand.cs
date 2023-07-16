 
using MediatR;


namespace MabnaDBTest.Core.Commands;

public class CreateTradeCommand : IRequest<long>
{
    public DateTime DateEn { get; set; }
    public Decimal Open { get; set; }
    public Decimal High { get; set; }
    public Decimal Low { get; set; }
    public Decimal Close { get; set; }
}
                                     