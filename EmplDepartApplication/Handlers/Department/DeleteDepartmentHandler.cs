using EmplDepartApplication.Commands.Department;
using EmplDepartCore.Exceptions;
using EmplDepartCore.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Handlers.Department
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository;

        public DeleteDepartmentHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetDepartmentByIdAsync(request.DepartmentId)
                ?? throw new NotFoundException("Department", request.DepartmentId);

            await _repository.DeleteDepartmentAsync(department.DepartmentId);
        }
    }
}
