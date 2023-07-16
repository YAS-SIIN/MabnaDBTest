using MediatR;



namespace MabnaDBTest.Core.Commands;

public class CreateInstrumentCommand : IRequest<long>
{
    public string Name { get; set; }
}
                                     