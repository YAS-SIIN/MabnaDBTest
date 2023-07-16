
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.Repositories;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Infra.Data.Context;
using MabnaDBTest.Infra.Data.CoreContext;
using MabnaDBTest.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
namespace MabnaDBTest.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CoreDBContextInjection _context;
    //private bool disposed = false;                       

    public UnitOfWork(CoreDBContextInjection context)
    {

      // Database.SetInitializer<MyDataBase>(null);
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
   

}
