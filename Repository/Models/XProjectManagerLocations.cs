using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class XProjectManagerLocations
    {
        public int ProjectManagerID { get; set; }
        public int LocationId { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ProjectManagers ProjectManagerI { get; set; }
    }
}
