using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.ViewModel
{
    public class EventManager
    {

        public Repository.Models.Events Events { get; set; }
        public Repository.Models.Employees Employees { get; set; }
        public Repository.Models.ProjectNumbers ProjectNumbers { get; set; }
        public Repository.Models.ProjectManagers ProjectManagers { get; set; }
        public Repository.Models.ProjectDevelopers ProjectDevelopers { get; set; }
        public Repository.Models.XProjectDeveloperLocations XProjectDeveloperLocations { get; set; }
        public Repository.Models.XProjectManagerLocations XProjectManagerLocations { get; set; }
        public Repository.Models.Locations LocationsDevelopers { get; set; }
        public Repository.Models.Locations LocationsManagers { get; set; }
        
    }
}
