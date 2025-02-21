using EmplDepartApplication.Commands.Department;
using EmplDepartCore.Entities;
using EmplDepartCore.Exceptions;
using EmplDepartCore.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmplDepartApplication.Handlers.Departments
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository;

        public UpdateDepartmentHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetDepartmentByIdAsync(request.DepartmentId)
                ?? throw new NotFoundException("Department", request.DepartmentId);

            // ✅ Update properties
            department.DepartmentName = request.DepartmentName;
            department.Description = request.Description;

            await _repository.UpdateDepartmentAsync(department);
        }
    }
}
