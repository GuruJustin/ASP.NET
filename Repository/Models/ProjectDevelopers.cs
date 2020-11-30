using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectDevelopers
    {
        public ProjectDevelopers()
        {
            ProjectNumbers = new HashSet<ProjectNumbers>();
            ProjectRevisions = new HashSet<ProjectRevisions>();
            XProjectDeveloperLocations = new HashSet<XProjectDeveloperLocations>();
        }

        public int ProjectDeveloperId { get; set; }
        public string ProjectDeveloperName { get; set; }

        public virtual ICollection<ProjectNumbers> ProjectNumbers { get; set; }
        public virtual ICollection<ProjectRevisions> ProjectRevisions { get; set; }
        public virtual ICollection<XProjectDeveloperLocations> XProjectDeveloperLocations { get; set; }
    }
}
