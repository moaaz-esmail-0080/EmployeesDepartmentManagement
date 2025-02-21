using EmplDepartApplication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Queries.Department
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
    {
        public int DepartmentId { get; set; }
    }
}
