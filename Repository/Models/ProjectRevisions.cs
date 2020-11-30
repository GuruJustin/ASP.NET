using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectRevisions
    {
        public int ProjectRevisionId { get; set; }
        public int ProjectId { get; set; }
        public short RevisionNumber { get; set; }
        public int? ProjectManagerId { get; set; }
        public int? ProjectDeveloperId { get; set; }
        public decimal? Hours { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public  bool ? AllDay { get; set; }
        public virtual Projects Project { get; set; }
        public virtual ProjectDevelopers ProjectDeveloper { get; set; }
        public virtual ProjectManagers ProjectManager { get; set; }
    }
}
