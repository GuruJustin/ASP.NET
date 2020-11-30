using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectManagers
    {
        public ProjectManagers()
        {
            ProjectNumbers = new HashSet<ProjectNumbers>();
            ProjectRevisions = new HashSet<ProjectRevisions>();
            XProjectManagerLocations = new HashSet<XProjectManagerLocations>();
        }

        public int ProjectManagerID { get; set; }
        public string ProjectManagerName { get; set; }

        public virtual ICollection<ProjectNumbers> ProjectNumbers { get; set; }
        public virtual ICollection<ProjectRevisions> ProjectRevisions { get; set; }
        public virtual ICollection<XProjectManagerLocations> XProjectManagerLocations { get; set; }
    }
}
