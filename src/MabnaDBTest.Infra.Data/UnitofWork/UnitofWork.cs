
using Dapper;

using MabnaDBTest.Domain.Entities;
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.Repositories;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Infra.Data.Context;
using MabnaDBTest.Infra.Data.CoreContext;
using MabnaDBTest.Infra.Data.Repositories;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Data;

namespace MabnaDBTest.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CoreDBContextInjection _context;


    public UnitOfWork(CoreDBContextInjection context)
    {

        if (context == null)
            throw new ArgumentException("DB context is null!");
        _context = context;
    }


    /// <summary>
    /// Generate Repository of Entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbContextType"></param>
    /// <returns></returns>
    public IGenericRepository<T> GetRepository<T>(EnumDBContextType dbContextType) where T : class
    {
        return new GenericRepository<T>(_context, dbContextType);
    }

    public IEnumerable<T> SqlQueryView<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class
    {
        //DynamicParameters parameterDapper = new DynamicParameters();

        //foreach (SqlParameter item in parameters)
        //{
        //    parameterDapper.Add(item.ParameterName, item.Value);
        //}
        IDbConnection dbConnection = _context._main_MabnaDBContext.Database.GetDbConnection();
 
        switch (dbContextType)
        {
            case EnumDBContextType.MAIN_MabnaDBContext:
                dbConnection = _context._main_MabnaDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.READ_MabnaDBContext:
                dbConnection = _context._read_MabnaDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.WRITE_MabnaDBContext:
                dbConnection = _context._write_MabnaDBContext.Database.GetDbConnection();
                break;
            default:
                dbConnection = _context._main_MabnaDBContext.Database.GetDbConnection();
                break;
        }

        using (dbConnection)
        {
            return dbConnection.Query<T>(sql, parameters);
        }
    }
    
    public async Task<IEnumerable<T>> SqlQueryViewAsync<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class
    {
        //DynamicParameters parameterDapper = new DynamicParameters();

        //foreach (SqlParameter item in parameters)
        //{
        //    parameterDapper.Add(item.ParameterName, item.Value);
        //}
        IDbConnection dbConnection = _context._main_MabnaDBContext.Database.GetDbConnection();
 
        switch (dbContextType)
        {
            case EnumDBContextType.MAIN_MabnaDBContext:
                dbConnection = _context._main_MabnaDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.READ_MabnaDBContext:
                dbConnection = _context._read_MabnaDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.WRITE_MabnaDBContext:
                dbConnection = _context._write_MabnaDBContext.Database.GetDbConnection();
                break;
            default:
                dbConnection = _context._main_MabnaDBContext.Database.GetDbConnection();
                break;
        }

        using (dbConnection)
        {
            return await dbConnection.QueryAsync<T>(sql, parameters);
        }
    }

}
