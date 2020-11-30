using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        WesternSchedulerContext _context;
        public DepartmentServices(WesternSchedulerContext context)
        {
            _context = context;
        }

        public List<Departments> GetListOfDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}
