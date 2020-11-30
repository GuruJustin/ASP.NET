using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class XProjectDeveloperLocations
    {
        public int ProjectDeveloperId { get; set; }
        public int LocationId { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ProjectDevelopers ProjectDeveloper { get; set; }
    }
}
