using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
   public class SchedulerInfoServices:ISchedulerInfoServices
    {
        WesternSchedulerContext context;
        public SchedulerInfoServices(WesternSchedulerContext _context)
        {
            context = _context;
        }

        public JsonModel GetSchedulerInfoList()
        {
            var employeeList = context.Employees.ToList();
            var departmentList = context.Departments.Select(p=>new ViewModelDepartments { DepartmentId= p.DepartmentId, DepartmentName= p.DepartmentName }).ToList();
            var locations = context.Locations.Select(p=>new  ViewModelLocations {LocationId=p.LocationId,LocationName= p.LocationName }).ToList();
            var listOfValues = context.ListOfValues.ToList();
            var projectNumbers = context.ProjectNumbers.Select(p => new ViewModelProjectNumber { ProjectNumberId= p.ProjectNumberId, ProjectNumber= p.ProjectNumber }).ToList();
            //var projectManager = context.ProjectManagers.ToList();
            var projectDeveloper = context.ProjectDevelopers.Select(p=> new { p.ProjectDeveloperId, p.ProjectDeveloperName }).ToList();


            var clients = context.Clients.Select(p=>new ViewModelClient{ClientId=p.ClientId, ClientName=p.ClientName}).ToList();

            //var projectDeveloprLocationsdata = (from ep in context.XProjectDeveloperLocations
            //                                join p in context.Locations on ep.LocationId equals p.LocationId
            //                                join d in context.ProjectDevelopers on ep.ProjectDeveloperId equals d.ProjectDeveloperId
            //                                where ep.LocationId == p.LocationId && projectDeveloper.Select(p => p.ProjectDeveloperId).Contains(d.ProjectDeveloperId)
            //                                select new ProjectDeveloperLocations
            //                                {
            //                                    Children = null,
            //                                    Name = p.LocationName,
            //                                    Id = p.LocationId
            //                                }

            //                                ).Distinct().ToList();


            var projectDevelopr = (from ep in context.XProjectDeveloperLocations
                                   join p in context.Locations on ep.LocationId equals p.LocationId
                                   join d in context.ProjectDevelopers on ep.ProjectDeveloperId equals d.ProjectDeveloperId
                                   where ep.LocationId == p.LocationId
                                   select new ProjectDeveloperList
                                   {
                                       Name = d.ProjectDeveloperName,
                                       Id = d.ProjectDeveloperId,
                                       LocationId=p.LocationId

                                   }).Distinct().ToList();

            ProjectDeveloperLocations obj = new ProjectDeveloperLocations();

            var projectDeveloprLocations = (from ep in context.XProjectDeveloperLocations
                                            join p in context.Locations on ep.LocationId equals p.LocationId
                                            join d in context.ProjectDevelopers on ep.ProjectDeveloperId equals d.ProjectDeveloperId
                                            where ep.LocationId == p.LocationId && projectDeveloper.Select(p => p.ProjectDeveloperId).Contains(d.ProjectDeveloperId)
                                            select new ProjectDeveloperLocations
                                            {
                                                Children = projectDevelopr,
                                                Name = p.LocationName,
                                                Id = p.LocationId
                                            }
                                            ).Distinct().ToList();


          foreach(var x in projectDeveloprLocations)
            {

                x.Children = x.Children.Where(p => p.LocationId == x.Id).ToList();

            }


            var projectManagerList = (from ep in context.XProjectManagerLocations
                                      join p in context.Locations on ep.LocationId equals p.LocationId
                                      join d in context.ProjectManagers on ep.ProjectManagerID equals d.ProjectManagerID
                                      where ep.LocationId == p.LocationId
                                      select new ProjectManagerList
                                      {

                                          Name = d.ProjectManagerName,
                                          Id = d.ProjectManagerID,
                                          LocationId=p.LocationId
                                      }
                                      ).Distinct().ToList();


            var projectManagerLocations = (from ep in context.XProjectManagerLocations
                                           join p in context.Locations on ep.LocationId equals p.LocationId
                                           join d in context.XProjectManagerLocations on ep.ProjectManagerID equals d.ProjectManagerID
                                           where ep.LocationId == p.LocationId
                                           select new ProjectManagerLocations
                                           {
                                               Children = projectManagerList,
                                               Name = p.LocationName,
                                               Id = p.LocationId
                                           }
                                       ).Distinct().ToList();

            foreach(var x in  projectManagerLocations)
            {
                x.Children = x.Children.Where(p => p.LocationId == x.Id).ToList();



            }



            var schedularList =
           new SchedulerInfo
           {
                Resources = employeeList.Select(p => new Employee { DepartmentId = p.DepartmentId, DisplayName = p.DisplayName, EmployeeId = p.EmployeeId, FirstName = p.FirstName, LastName = p.LastName }).ToList(),
                Departments = departmentList,
                Location = locations,
                ListOfValue = listOfValues,
                Clients = clients,
              // ProjectDeveloper = projectDeveloper.Select(p => new ProjectDeveloper { ProjectDeveloperId = p.ProjectDeveloperId, ProjectDeveloperName = p.ProjectDeveloperName }).ToList(),
               // ProjectManager = projectManager.Select(p => new ProjectManager { ProjectManagerId = p.ProjectManagerId, ProjectManagerName = p.ProjectManagerName }).ToList(),
               ProjectNumber = projectNumbers,
               ProjectManagerLocations = projectManagerLocations,
               ProjectDeveloperLocations = projectDeveloprLocations
           };


            //var listData = new JsonModel(
            //    schedularList,
            //    string.Empty,
            //   200,
            //   string.Empty
            //);
            //return listData;
            return new JsonModel(schedularList, "", (int)Repository.ViewModel.HttpStatusCode.OK, "");


        }
        public void DeleteSchedulerInfo(int id)
        {
            //var schedulerinfo = (from);
        }

        public void UpdateSchedulerInfo(SchedulerInfo model)
        {
            
            //var Employee = context.Employees.Where(p => p.EmployeeId == model.Resources.EmployeeId);
           
            //if (Employee != null)
            //{
            //    context.Entry(model.Resources).State = EntityState.Modified;
            //    context.SaveChanges();
            //}
            //var ProjectNumber = context.ProjectNumbers.Where(p => p.ProjectNumberId == model.ProjectNumber.ProjectNumberId);
            //if (ProjectNumber != null)
            //{
            //    context.Entry(model.ProjectNumber).State = EntityState.Modified;
            //    context.SaveChanges();
            //}
            //var data = context.ProjectDevelopers.Where(p => p.ProjectDeveloperId == model.ProjectDeveloper.ProjectDeveloperId);
            //if (data != null)
            //{
            //    context.Entry(model.ProjectDeveloper).State = EntityState.Modified;
            //    context.SaveChanges();
            //}

            //var locData = context.ProjectManagers.Where(p => p.ProjectManagerId == model.ProjectManager.ProjectManagerId);
            //if (locData != null)
            //{
            //    context.Entry(model.ProjectDeveloper).State = EntityState.Modified;
            //    context.SaveChanges();
            //}

            //var listofval = context.ListOfValues.Where(p => p.Id == model.ListOfValue.Id);
            //if (listofval != null)
            //{
            //    context.Entry(model.ListOfValue).State = EntityState.Modified;
            //    context.SaveChanges();
            //}
            //var deptt = context.Departments.Where(p => p.DepartmentId == model.Departments.DepartmentId);
            //if (deptt != null)
            //{
            //    context.Entry(model.Departments).State = EntityState.Modified;
            //    context.SaveChanges();
            //}
        }

        //public void SaveSchedulerInfo(SchedulerInfo model)
        //{

        //    //  ProjectDevelopers developer = new ProjectDevelopers();

        //    var developer = model.ProjectDeveloper.Select(p => new ProjectDevelopers { ProjectDeveloperId = p.ProjectDeveloperId, ProjectDeveloperName = p.ProjectDeveloperName }).ToList();

        //    context.ProjectDevelopers.AddRange(developer);

        //    var ProjectNumbers = model.ProjectNumber.Select(p => new Repository.Models.ProjectNumbers { AddressLine1= p.AddressLine1, AddressLine2=p.AddressLine2 , City=p.City, ClientId=p.ClientId, ProjectDeveloperId=p.ProjectDeveloperId, CreatedBy=p.CreatedBy, ProjectManagerId=p.ProjectManagerId, DateCreated=p.DateCreated, DateModified=p.DateModified, LocationId=p.LocationId, ModifiedBy= p.ModifiedBy,  ProjectNumberId=p.ProjectNumberId, ZipCode=p.ZipCode, NickName=p.NickName }).ToList();
        //    //context.ProjectDevelopers.Add(model.ProjectDevelopers);
        //    //context.Locations.Add(model.LocationsDevelopers);
        //    //context.Locations.Add(model.LocationsManagers);
        //    //context.ProjectManagers.Add(model.ProjectManagers);
        //    //context.SaveChanges();
        //    //context
        //    context.ProjectNumbers.AddRange(ProjectNumbers);

        //    var ProjectManagers = model.ProjectManager.Select(p => new ProjectManager { ProjectManagerId=p.ProjectManagerId, ProjectManagerName=p.ProjectManagerName }).ToList();
        //    context.ProjectManagers.AddRange((IEnumerable<ProjectManagers>)ProjectManagers);

        //    var listofvalues = model.ListOfValue.Select(p => new ListOfValues { Id=p.Id,Category=p.Category,Value=p.Value,Text=p.Text }).ToList();
        //    context.ListOfValues.AddRange(listofvalues);

        //    var loc = model.Location.Select(p => new Locations {LocationId=p.LocationId,LocationName=p.LocationName }).ToList();
        //    context.Locations.AddRange(loc);

        //    var departments = model.Departments.Select(p => new Departments { DepartmentId = p.DepartmentId, DepartmentName = p.DepartmentName }).ToList();
        //    context.Departments.AddRange(departments);

        //    var employees = model.Resources.Select(p => new Employees { EmployeeId=p.EmployeeId, DisplayName=p.DisplayName,FirstName=p.FirstName,LastName=p.LastName, DepartmentId=p.DepartmentId }).ToList();
        //    context.Employees.AddRange(employees);
        //    context.SaveChanges();
        //    //context
        //    //context.Employees.Add(model.Employees);
        //    //context.SaveChanges();
        //    //context
        //    //context.ListOfValues.Add(model.ListOfValues);
        //    //context.SaveChanges();
        //    //context
        //    //context
        //    //context.Departments.Add(model.Departments);
        //    //context.SaveChanges();
           
        //}
        //public SchedulerInfo GetSchedulerInfoByProjectNumberID(int id)
        //{

        //}

        //public List<SchedulerInfo> GetSchedulerInfoList()
        //{

        //}

    }
}
