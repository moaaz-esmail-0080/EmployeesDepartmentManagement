﻿using EmplDepartApplication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplDepartApplication.Queries.Employees
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDto>>
    {
    }
}
