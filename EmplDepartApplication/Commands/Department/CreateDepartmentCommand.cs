using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Commands.Department
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string DepartmentName { get; set; }  
        public string Description { get; set; }    
    }
}
