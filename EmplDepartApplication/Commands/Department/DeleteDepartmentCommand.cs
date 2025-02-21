using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Commands.Department
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int DepartmentId { get; set; }
    }
}
