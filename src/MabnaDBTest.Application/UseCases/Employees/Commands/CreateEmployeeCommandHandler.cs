using MabnaDBTest.Common.Mapper;
using MabnaDBTest.Core.Commands.Tradee;
using MabnaDBTest.Domain.Entities.MabnaDBTest.Tradees;
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;

using MediatR;

namespace MabnaDBTest.Application.UseCases.Tradees.Commands
{
    public class CreateTradeeCommandHandler : IRequestHandler<CreateTradeeCommand, long>
    {
        private readonly IUnitOfWork _uw;
        public CreateTradeeCommandHandler(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<long> Handle(CreateTradeeCommand request, CancellationToken cancellationToken)
        {
            Tradee inputData = Mapper<Tradee, CreateTradeeCommand>.CommandToEntity(request);
            await _uw.GetRepository<Tradee>(EnumDBContextType.WRITE_MabnaDBContext).AddAsync(inputData, cancellationToken, true);
 
            return inputData.Id;
        }
    }
}
