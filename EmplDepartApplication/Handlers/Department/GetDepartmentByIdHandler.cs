using EmplDepartApplication.DTOs;
using EmplDepartApplication.Queries.Department;
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
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentByIdHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetDepartmentByIdAsync(request.DepartmentId)
                ?? throw new NotFoundException("Department", request.DepartmentId);

            return new DepartmentDto
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
        }
    }
}
