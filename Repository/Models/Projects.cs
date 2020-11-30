using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Projects
    {
        public Projects()
        {
            ProjectRevisions = new HashSet<ProjectRevisions>();
        }

        public int ProjectId { get; set; }
        public int? ProjectNumberId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }
        public string ProjectType { get; set; }
        public int? DepartmentId { get; set; }
        public int? ParentProjectId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual ProjectNumbers ProjectNumber { get; set; }
        public virtual ICollection<ProjectRevisions> ProjectRevisions { get; set; }
    }
}
