﻿
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

        StringBuilder SqlQuery = new StringBuilder(" GO");

        SqlQuery.AppendLine(" IF Not Exists(Select * FRom  sys.indexes Where Name ='IX_NonClusteredIndex_Trades_InstrumentId')");
        SqlQuery.AppendLine(" Begin");
        SqlQuery.AppendLine(" 	CREATE NONCLUSTERED INDEX IX_NonClusteredIndex_Trades_InstrumentId ON [dbo].[Trades]");
        SqlQuery.AppendLine(" 	([InstrumentId] ASC)");
        SqlQuery.AppendLine(" 	INCLUDE([Id],[DateEn],[Open],[High],[Low],[Close]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]");
        SqlQuery.AppendLine(" End");
        SqlQuery.AppendLine(" ");
        SqlQuery.AppendLine(" SELECT Instruments.Name, Trades.DateEn, Trades.[Open], Trades.High, Trades.Low, Trades.[Close]");
        SqlQuery.AppendLine("   FROM [dbo].[Instruments]");
        SqlQuery.AppendLine("   Outer apply");
        SqlQuery.AppendLine("   (SELECT        TOP (1)   DateEn, [Open], High, Low, [Close]");
        SqlQuery.AppendLine(" FROM            Trades Where InstrumentId=Instruments.id Order by Trades.Id desc) Trades");


        var response = await _uw.SqlQueryViewAsync<GetAllTradeResponse>(EnumDBContextType.READ_MabnaDBContext, SqlQuery.ToString());

        //GetAllTradeResponse response = Mapper<GetAllTradeResponse, List<Domain.Entities.Instrument>>.MappClasses(databaseData.ToList());

        return CustomResponseDto<IEnumerable<GetAllTradeResponse>>.Success(EnumResponses.Success, response);
    }
}