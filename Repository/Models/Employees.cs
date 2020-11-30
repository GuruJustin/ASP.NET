using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Projects = new HashSet<Projects>();
            Events = new HashSet<Events>();
        }

        public int EmployeeId { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
