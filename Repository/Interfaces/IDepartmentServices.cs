using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public  interface IDepartmentServices
    {
        public List<Departments> GetListOfDepartments();
    }
}
