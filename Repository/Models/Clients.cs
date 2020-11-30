using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Clients
    {
        public Clients()
        {
            ProjectNumbers = new HashSet<ProjectNumbers>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<ProjectNumbers> ProjectNumbers { get; set; }
    }
}
