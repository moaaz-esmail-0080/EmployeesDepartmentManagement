using EmplDepartApplication.Commands.Employees;
using EmplDepartCore.Entities;
using EmplDepartCore.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Handlers.Employees
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repository;

        public CreateEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DepartmentId = request.DepartmentId
            };

            await _repository.AddEmployeeAsync(employee);
            return employee.EmployeeId;
        }
    }
}
