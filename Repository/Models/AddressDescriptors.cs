using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class AddressDescriptors
    {
        public int AddressDescriptorId { get; set; }
        public int ProjectNumberId { get; set; }
        public string AddressDescriptorType { get; set; }
        public string AddressDescriptorValue { get; set; }

        public virtual ProjectNumbers ProjectNumber { get; set; }
    }
}
