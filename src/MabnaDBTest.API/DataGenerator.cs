using MabnaDBTest.Common.Enums;
using MabnaDBTest.Domain.Entities;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Infra.Data.UnitOfWork;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Data;
using System.Diagnostics;
using System.Text;

namespace MabnaDBTest.API
{
    public class DataGenerator
    {
        /// <summary>
        /// افزودن اطلاعات اولیه
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            // افزودن چند ردیف نماد
            if (!_unitOfWork.GetRepository<Instrument>(Domain.Enums.EnumDBContextType.READ_MabnaDBContext).ExistData())
            {
                List<Instrument> instruments = new List<Instrument>() {
                new Instrument { Name = "Bank1", Status = (short)EnumBaseStatus.Active },
                new Instrument { Name = "Bank2", Status = (short)EnumBaseStatus.Active },
                new Instrument { Name = "Company1", Status = (short)EnumBaseStatus.Active },
                new Instrument { Name = "Company2", Status = (short)EnumBaseStatus.Active }
            };
                _unitOfWork.GetRepository<Instrument>(Domain.Enums.EnumDBContextType.WRITE_MabnaDBContext).AddRangeAsync(instruments, new CancellationToken(), true);
            }


            // افزودن چند ردیف معامله
            if (!_unitOfWork.GetRepository<Trade>(Domain.Enums.EnumDBContextType.READ_MabnaDBContext).ExistData())
            {
                var _instrumentList = _unitOfWork.GetRepository<Instrument>(Domain.Enums.EnumDBContextType.READ_MabnaDBContext).GetAll().ToList();

                Random random = new Random();
                List<Trade> trades = new List<Trade>();
                foreach (Instrument item in _instrumentList)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        trades.Add(new Trade { 
                            Id = item.Id, 
                            DateEn = DateTime.Now,
                            Open = random.Next(1000, 9999),
                            High = random.Next(1000, 9999),
                            Low = random.Next(100, 999),
                            Close = random.Next(100,999),
                            Status = (short)EnumBaseStatus.Active});
                    }
                }
                _unitOfWork.GetRepository<Trade>(Domain.Enums.EnumDBContextType.WRITE_MabnaDBContext).AddRangeAsync(trades, new CancellationToken(), true);

            }

        }
    }
}
