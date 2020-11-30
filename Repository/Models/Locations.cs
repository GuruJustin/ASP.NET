using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Locations
    {
        public Locations()
        {
            ProjectNumbers = new HashSet<ProjectNumbers>();
            XProjectDeveloperLocations = new HashSet<XProjectDeveloperLocations>();
            XProjectManagerLocations = new HashSet<XProjectManagerLocations>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Style_BackgroundColor { get; set; }
        public string Style_Border { get; set; }
        public string Style_Color { get; set; }
        public string Style_ClosedColor { get; set; }
        public virtual ICollection<ProjectNumbers> ProjectNumbers { get; set; }
        public virtual ICollection<XProjectDeveloperLocations> XProjectDeveloperLocations { get; set; }
        public virtual ICollection<XProjectManagerLocations> XProjectManagerLocations { get; set; }
    }
}
