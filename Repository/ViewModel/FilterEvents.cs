using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
   public class FilterEvents
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Events
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int ProjectNumberId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; }
        public string EventColor { get; set; }
        public string Style { get; set; }

    }

    public class EventsRelatedInfo
    {

        public EventsRelatedInfo()
        {
            this.Events = new Events();
            this.ResourcesList = new Resources();
            this.ProjectNumberList = new ProjectNumbers();
            this.ClientList = new Clients();
            this.DepartmentList = new Department();
        }

        public Events Events { get; set; }
        public Resources ResourcesList { get; set; }
        public ProjectNumbers ProjectNumberList { get; set; }
        public Clients ClientList { get; set; }

        public Department DepartmentList { get; set; }

    }


    public class Resources
    {
        public int EmployeeId { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }

    }

    public class  ProjectNumbers
    {

        public int ProjectNumberId { get; set; }
        public string ProjectNumber { get; set; }
        public string NickName { get; set; }
        public int ClientId { get; set; }
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

    }

    public class Clients
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }


}
