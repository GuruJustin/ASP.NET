using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
   public class SchedulerInfo
    {

        public SchedulerInfo()
        {
            this.Departments = new List<ViewModelDepartments>();
            this.Location = new List<ViewModelLocations>();
            this.ListOfValue = new List<ListOfValues>();
            this.ProjectNumber = new List<ViewModelProjectNumber>();
            this.ProjectManager = new List<ViewModelProjectManagers>();
            this.ProjectDeveloper = new List<ViewModelProjectDeveloper>();
            this.ProjectDeveloperLocations = new List<ProjectDeveloperLocations>();
            this.ProjectManagerLocations = new List<ProjectManagerLocations>();
            this.Employees = new List<ViewModelEmployees>();
            this.Clients = new List<ViewModelClient>();
            this.AddressDescriptors = new List<ViewModelAddressDescriptor>();
        }
        public List<Employee> Resources { get; set; }
        public List<ViewModelDepartments> Departments { get; set; }
        public List<ViewModelLocations> Location { get; set; }
        public List<ListOfValues> ListOfValue { get; set; }
        public List<ViewModelProjectNumber> ProjectNumber { get; set; }
        public List<ViewModelProjectManagers> ProjectManager { get; set; }
        public List<ViewModelProjectDeveloper> ProjectDeveloper { get; set; }
        public List<ProjectManagerLocations> ProjectManagerLocations { get; set; }
        public List<ProjectDeveloperLocations> ProjectDeveloperLocations { get; set; }
        public List<ViewModelEmployees> Employees { get; set; }

        public List<ViewModelClient> Clients { get; set; }
        public List<ViewModelAddressDescriptor> AddressDescriptors { get; set; }
    }

    public class ViewModelAddressDescriptor
    {
        public int AddressDescriptorId { get; set; }

        public string AddressDescriptorType { get; set; }

        public string AddressDescriptorValue { get; set; }
    }

    public class ViewModelClient
    {
        public int ? ClientId { get; set; }

        public string ClientName { get; set; }

    }
    public class ViewModelProjectManagers
    {
        public int ? ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set; }
    }
    public class ViewModelDepartments
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

    }
    public class ViewModelLocations
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

    }

    public class ViewModelEmployees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

    }
    public class ViewModelProjectDeveloper
    {
        public int ProjectDeveloperId { get; set; }
        public string ProjectDeveloperName { get; set; }
    }

    public class ViewModelProjectNumber
    {
        public  int ? ProjectNumberId { get; set; }

        public string ProjectNumber { get; set; }

    }
    public class ProjectDeveloperLocations
    {

        public ProjectDeveloperLocations()
        {
            this.Children = new List<ProjectDeveloperList>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       public List<ProjectDeveloperList> Children { get; set; }
    }

    public class ProjectDeveloperList
    {

        public ProjectDeveloperList()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }





    }

    public class ProjectManagerLocations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectManagerList> Children { get; set; }
    }

    public class ProjectManagerList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class ProjectNumberList
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
    public class ProjectManager
    {
        public int ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set; }
    }

    public class ProjectDeveloper
    {
        public int ProjectDeveloperId { get; set; }
        public string ProjectDeveloperName { get; set; }

    }

    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }

    }

}
