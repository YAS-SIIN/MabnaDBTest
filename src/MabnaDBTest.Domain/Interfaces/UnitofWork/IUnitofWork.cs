
using Dapper;

using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

using System;
                                    
namespace MabnaDBTest.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork 
{
    IGenericRepository<T> GetRepository<T>(EnumDBContextType dbContextType) where T : class;
    public IEnumerable<T> SqlQueryView<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class;

    Task<IEnumerable<T>> SqlQueryViewAsync<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class;
}
