using EmplDepartApplication.DTOs;
using EmplDepartApplication.Queries.Department;
using EmplDepartCore.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Handlers.Department
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentsHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _repository.GetDepartmentsAsync();

            return departments.Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                Description = d.Description
            }).ToList();
        }
    }

}
