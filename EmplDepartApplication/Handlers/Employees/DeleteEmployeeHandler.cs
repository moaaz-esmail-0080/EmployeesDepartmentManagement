using EmplDepartApplication.Commands.Employees;
using EmplDepartCore.Exceptions;
using EmplDepartCore.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmplDepartApplication.Handlers.Employees
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetEmployeeByIdAsync(request.EmployeeId)
                ?? throw new NotFoundException("Employee", request.EmployeeId);

            await _repository.DeleteEmployeeAsync(employee.EmployeeId); 
        }
    }
}
