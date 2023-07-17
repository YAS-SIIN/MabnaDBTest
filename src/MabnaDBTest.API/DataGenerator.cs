using MabnaDBTest.Common.Enums;
using MabnaDBTest.Domain.Entities;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Infra.Data.UnitOfWork;

using Microsoft.EntityFrameworkCore;

namespace MabnaDBTest.API
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

            if (!_unitOfWork.GetRepository<Instrument>(Domain.Enums.EnumDBContextType.WRITE_MabnaDBContext).ExistData())
            {
                List<Instrument> trade = new List<Instrument>() {
                new Instrument { Name = "Bank1", Status = (short)EnumBaseStatus.Active, CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Instrument { Name = "Bank2", Status = (short)EnumBaseStatus.Active, CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Instrument { Name = "Company1", Status = (short)EnumBaseStatus.Active, CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Instrument { Name = "Company2", Status = (short)EnumBaseStatus.Active, CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now }
            };
                _unitOfWork.GetRepository<Instrument>(Domain.Enums.EnumDBContextType.WRITE_MabnaDBContext).AddRangeAsync(trade, new CancellationToken(), true);
            }
        }
    }
}
