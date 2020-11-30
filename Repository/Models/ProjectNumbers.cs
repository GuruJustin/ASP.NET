using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectNumbers
    {
        public ProjectNumbers()
        {
            AddressDescriptors = new HashSet<AddressDescriptors>();
            Projects = new HashSet<Projects>();
            Events = new HashSet<Events>();
        }
        public int ProjectNumberId { get; set; }
        public string ProjectNumber { get; set; }
        public string NickName { get; set; }
        public int? ClientId { get; set; }
        public int LocationId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int ProjectManagerId { get; set; }
        public int ProjectDeveloperId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Clients Client { get; set; }
        public virtual Locations Location { get; set; }
        public virtual ProjectDevelopers ProjectDeveloper { get; set; }
        public virtual ProjectManagers ProjectManager { get; set; }
        public virtual ICollection<AddressDescriptors> AddressDescriptors { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<Events> Events { get; set; }
    }
}
