
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using MabnaDBTest.Core.Queries;

namespace MabnaDBTest.Application.UseCases.Trade.Queries;

public class GetAllTradeQueryHandler : IRequestHandler<GetAllTradeQuery, CustomResponseDto<IEnumerable<GetAllTradeResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllTradeQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<CustomResponseDto<IEnumerable<GetAllTradeResponse>>> Handle(GetAllTradeQuery request,
        CancellationToken cancellationToken)
    {

        StringBuilder SqlQuery = new StringBuilder("");

    
        SqlQuery.AppendLine(" SELECT Instruments.Name, Trades.DateEn, Trades.[Open], Trades.High, Trades.Low, Trades.[Close]");
        SqlQuery.AppendLine("   FROM [dbo].[Instruments]");
        SqlQuery.AppendLine("   Outer apply");
        SqlQuery.AppendLine("   (SELECT        TOP (1)   DateEn, [Open], High, Low, [Close]");
        SqlQuery.AppendLine(" FROM   Trades Where InstrumentId=Instruments.id Order by Trades.Id desc) Trades");


        var response = await _uw.SqlQueryViewAsync<GetAllTradeResponse>(EnumDBContextType.READ_MabnaDBContext, SqlQuery.ToString());
         
        return CustomResponseDto<IEnumerable<GetAllTradeResponse>>.Success(EnumResponses.Success, response);
    }
 
}