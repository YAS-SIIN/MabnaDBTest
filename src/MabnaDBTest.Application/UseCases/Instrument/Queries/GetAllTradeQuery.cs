
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
        /*
         * USE [Lerning]
 
        IF Not Exists(Select 1 FRom  sys.indexes Where Name = N'IX_NonClusteredIndex_Trade_InstrumentId')
Begin
    CREATE NONCLUSTERED INDEX IX_NonClusteredIndex_Trade_InstrumentId ON[dbo].[Trade]
        (


        [InstrumentId] ASC
	)
	INCLUDE([Id],[DateEn],[Open],[High],[Low],[Close]) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
End
        SELECT Instrument.Name, Trade.DateEn, Trade.[Open], Trade.High, Trade.Low, Trade.[Close]
  FROM [Lerning].[dbo].[Instrument]
  Outer apply
  (SELECT        TOP (1)   DateEn, [Open], High, Low, [Close]
FROM            Trade Where InstrumentId=Instrument.id Order by Trade.Id desc)
  Trade
         */
        StringBuilder SqlQuery = new StringBuilder(" SELECT instruments.Name, trades.*");
        SqlQuery.AppendLine(" FROM dbo.Instruments instruments");
        SqlQuery.AppendLine(" JOIN dbo.Trades trades ON instruments.Id = trades.InstrumentId");
        SqlQuery.AppendLine(" WHERE trades.DateEn = (SELECT MAX(DateEn) FROM dbo.Trades WHERE InstrumentId = instruments.Id)");
        SqlQuery.AppendLine(" ORDER BY instruments.Id;");
       var response = await _uw.SqlQueryViewAsync<GetAllTradeResponse>(EnumDBContextType.READ_MabnaDBContext, SqlQuery.ToString());
    
        //GetAllTradeResponse response = Mapper<GetAllTradeResponse, List<Domain.Entities.Instrument>>.MappClasses(databaseData.ToList());

        return CustomResponseDto<IEnumerable<GetAllTradeResponse>>.Success(EnumResponses.Success, response);
    }
}