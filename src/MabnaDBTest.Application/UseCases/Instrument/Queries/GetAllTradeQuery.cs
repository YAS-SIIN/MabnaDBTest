
using MabnaDBTest.Common.Enums;
using MabnaDBTest.Common.Mapper;
using MabnaDBTest.Domain.DTOs;
using MabnaDBTest.Domain.DTOs.Instrument;
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Domain.Entities;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Text;

namespace MabnaDBTest.Application.UseCases.Instrument.Queries;

public class GetAllTradeQuery : IRequest<CustomResponseDto<IEnumerable<GetAllTradeResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllTradeQuery(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<CustomResponseDto<IEnumerable<GetAllTradeResponse>>> Handle(
        CancellationToken cancellationToken)
    {
        StringBuilder SqlQuery = new StringBuilder(" SELECT instruments.Name, trades.*");
        SqlQuery.AppendLine(" FROM dbo.Instruments instruments");
        SqlQuery.AppendLine(" JOIN dbo.Trades trades ON instruments.Id = trades.InstrumentId");
        SqlQuery.AppendLine(" WHERE trades.id = (SELECT MAX(id) FROM dbo.Trades WHERE InstrumentId = instruments.Id)");
        SqlQuery.AppendLine(" ORDER BY instruments.Id;");
       var response = await _uw.SqlQueryViewAsync<GetAllTradeResponse>(EnumDBContextType.READ_MabnaDBContext, SqlQuery.ToString());
    
        //GetAllTradeResponse response = Mapper<GetAllTradeResponse, List<Domain.Entities.Instrument>>.MappClasses(databaseData.ToList());

        return CustomResponseDto<IEnumerable<GetAllTradeResponse>>.Success(EnumResponses.Success, response);
    }
}