
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.Repositories;

using System;
                                    
namespace MabnaDBTest.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork 
{
    IGenericRepository<T> GetRepository<T>(EnumDBContextType dbContextType) where T : class;
   
}
