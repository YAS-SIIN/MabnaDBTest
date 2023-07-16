using MabnaDBTest.Common.Mapper;
using MabnaDBTest.Core.Commands.Employee;
using MabnaDBTest.Domain.Entities.MabnaDBTest.Employees;
using MabnaDBTest.Domain.Enums;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;

using MediatR;

namespace MabnaDBTest.Application.UseCases.Employees.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, long>
    {
        private readonly IUnitOfWork _uw;
        public CreateEmployeeCommandHandler(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<long> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee inputData = Mapper<Employee, CreateEmployeeCommand>.CommandToEntity(request);
            await _uw.GetRepository<Employee>(EnumDBContextType.WRITE_MabnaDBContext).AddAsync(inputData, cancellationToken, true);
 
            return inputData.Id;
        }
    }
}
