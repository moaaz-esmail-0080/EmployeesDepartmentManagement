using EmplDepartApplication.Commands.Employees;
using EmplDepartCore.Exceptions;
using EmplDepartCore.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Handlers.Employees
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;

        public UpdateEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetEmployeeByIdAsync(request.EmployeeId)
                ?? throw new NotFoundException("Employee", request.EmployeeId);

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.DepartmentId = request.DepartmentId;

            await _repository.UpdateEmployeeAsync(employee);
        }
    }
}
