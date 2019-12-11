using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;

namespace ProjectName.Api.Application.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employee;
        public CreateEmployeeCommandHandler(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Address address = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);
            Employee employee = new Employee(request.FullName, address, EmployeeType.Fresher);
            _employee.Add(employee);

            return await _employee.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
