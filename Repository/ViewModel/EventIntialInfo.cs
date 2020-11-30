using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
   public class EventIntialInfo
    {
         public string ClientName { get; set; }

         public string LocationName { get; set; }

         public string StyleBackGroundColor { get; set; }

        public string StyleBorder { get; set; }

        public string StyleColor { get; set; }

        public string StyleClosedColor { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int ? RevisionId { get; set; }

        public DateTime ? StartDate { get; set; }

        public DateTime ? EndDate { get; set; } 

        public int ? ProjectId { get; set; }

        public int ? EmployeeId { get; set; }

        public String Status { get; set; }

        public string ProjectType { get; set; }

        public int ? DepartmentId { get; set; }
    }
}
