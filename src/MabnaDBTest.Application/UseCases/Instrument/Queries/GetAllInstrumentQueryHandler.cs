
using MabnaDBTest.Common.Enums;
using MabnaDBTest.Common.Mapper;
using MabnaDBTest.Domain.DTOs;
using MabnaDBTest.Domain.DTOs.Instrument;
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Domain.Entities;

using MediatR;

namespace MabnaDBTest.Application.UseCases.Instrument.Queries;

public class GetAllInstrumentQueryHandler : IRequestHandler<GetAllInstrumentQuery, CustomResponseDto<GetAllInstrumentResponse>>
{

    private readonly IUnitOfWork _uw;
    public GetAllInstrumentQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<CustomResponseDto<GetAllInstrumentResponse>> Handle(GetAllInstrumentQuery request,
        CancellationToken cancellationToken)
    {
        var databaseData = await _uw.GetRepository<Domain.Entities.Instrument>(EnumDBContextType.READ_MabnaDBContext).GetAllAsync(cancellationToken);

        GetAllInstrumentResponse response = Mapper<GetAllInstrumentResponse, List<Domain.Entities.Instrument>>.MappClasses(databaseData.ToList());

        return CustomResponseDto<GetAllInstrumentResponse>.Success(EnumResponses.Success, response);
    }
}