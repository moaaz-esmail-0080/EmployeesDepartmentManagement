using EmplDepartApplication.Commands.Department;
using EmplDepartCore.Entities;
using EmplDepartCore.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmplDepartApplication.Handlers.Departments  // Changed to match plural naming convention
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _repository;

        public CreateDepartmentHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new EmplDepartCore.Entities.Department  
            {
                DepartmentName = request.DepartmentName,
                Description = request.Description
            };

            await _repository.AddDepartmentAsync(department);
            return department.DepartmentId;
        }
    }
}
