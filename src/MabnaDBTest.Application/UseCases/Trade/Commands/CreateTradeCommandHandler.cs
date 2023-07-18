using Azure;

using MabnaDBTest.Common.Enums;
using MabnaDBTest.Common.Mapper;
using MabnaDBTest.Core.Commands.Employee;
using MabnaDBTest.Domain.DTOs;
using MabnaDBTest.Domain.DTOs.Instrument;
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MabnaDBTest.Application.UseCases.Trade.Commands;
 
public class CreateTradeCommandHandler : IRequestHandler<CreateTradeCommand, CustomResponseDto<int>>
{
    private readonly IUnitOfWork _uw;
    public CreateTradeCommandHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<CustomResponseDto<int>> Handle(CreateTradeCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Trade inputData = Mapper<Domain.Entities.Trade, CreateTradeCommand>.MappClasses(request);
        await _uw.GetRepository<Domain.Entities.Trade>(EnumDBContextType.WRITE_MabnaDBContext).AddAsync(inputData, cancellationToken, true);
         
        return CustomResponseDto<int>.Success(EnumResponses.Success, inputData.Id);
    }
     
}
