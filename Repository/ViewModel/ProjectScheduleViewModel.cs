using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
    public class ProjectScheduleViewModel
    {
        public int clientId { get; set; }
       public string ProjectType { get; set; }

       public int ResourceId { get; set; }

       public int Departmentid { get; set; }

       public bool Allday { get; set; }

       public DateTime StartDate { get; set; }

      public DateTime EndDate { get; set; }
       public string ClientName { get; set; }

      public string  Address1 { get; set; }

     public string Address2 { get; set; }

     public string City { get; set; }

     public string State { get; set; }

      public string Status { get; set; }

     public string ZipCode { get; set; }

      public string NickName { get; set; }
    
     public int LocationId { get; set; }

     public int ProjectNumberId { get; set; }
     public int ProjectId { get; set; }

     public int ProjectRevisionId { get; set; }
    public List<AddressDescriptors> AddressDescriptors { get; set; }

    public int ProjectHours { get; set; }

    public short NumberOfRevision { get; set; }

    public int ProjectDeveloperId { get; set; }

    public int ProjectManagerId { get; set; }
   
    public List<ProjectNumbers> projectNumbers { get; set; }


    }
}
