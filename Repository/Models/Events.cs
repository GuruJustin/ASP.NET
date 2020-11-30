using Repository.Models;
using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Events
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int ProjectNumberId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; }
        public string EventColor { get; set; }
        public string Style { get; set; }
        public virtual Employees Resource { get; set; }
        public virtual ProjectNumbers ProjectNumbers { get; set; }

    }
}
