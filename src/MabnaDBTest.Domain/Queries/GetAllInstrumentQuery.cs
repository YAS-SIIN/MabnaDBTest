
using MabnaDBTest.Domain.DTOs;
using MabnaDBTest.Domain.DTOs.Instrument;

using MediatR;

namespace MabnaDBTest.Application.UseCases.Instrument.Queries;

public class GetAllInstrumentQuery : IRequest<CustomResponseDto<GetAllInstrumentResponse>>
{
}
