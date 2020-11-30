using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class ProjectSchedulerServices : IProjectScheduler
    {
        WesternSchedulerContext context;
        public ProjectSchedulerServices(WesternSchedulerContext _context)
        {
            context = _context;

        }

        public JsonModel GetProjectSchedulerList()
        {
            var projectList = context.Projects.Include("Employee").Include("ProjectNumber").Include("ProjectRevisions").Include(p => p.ProjectNumber.ProjectManager).Include(p => p.ProjectNumber.ProjectDeveloper).Include(p => p.ProjectNumber.Location).ToList();
            return new JsonModel(projectList, "", (int)HttpStatusCode.OK, "");
        }


        public JsonModel GetProjectSchedulerById(int id)
        {
            var projectList = context.Projects.Where(p => p.ProjectId == id).Include("Employee").Include("ProjectNumber").Include("ProjectRevisions").Include(p => p.ProjectNumber.ProjectManager).Include(p => p.ProjectNumber.ProjectDeveloper).Include(p => p.ProjectNumber.Location);
            return new JsonModel(projectList, "", (int)HttpStatusCode.OK, "");
        }


        public JsonModel SaveProjectScheduler(ProjectScheduleViewModel model)
        {
            Models.Clients clientData = new Models.Clients();
            clientData.ClientName = model.ClientName;
            clientData.City = model.City;
            clientData.State = model.State;
            clientData.ZipCode = model.ZipCode;
            clientData.AddressLine1 = model.Address1;
            clientData.AddressLine2 = model.Address2;
            context.Clients.Add(clientData);
            context.SaveChanges();

            Models.ProjectNumbers obj = new Models.ProjectNumbers();
            obj.ProjectManagerId = model.ProjectManagerId;
            obj.ProjectDeveloperId = model.ProjectDeveloperId;
            obj.NickName = model.NickName;
            obj.LocationId = model.LocationId;
            obj.AddressLine1 = model.Address1;
            obj.AddressLine2 = model.Address2;
            obj.ClientId = clientData.ClientId;
            obj.DateCreated = DateTime.Now;
            obj.DateModified = DateTime.Now;
            string TotalPNnumber = (context.ProjectNumbers.ToList().Count+1).ToString();
            obj.ProjectNumber = "PN0000"+ TotalPNnumber;
            context.ProjectNumbers.Add(obj);
            context.SaveChanges();
            foreach(var x in model.AddressDescriptors)
            {
                x.ProjectNumberId = obj.ProjectNumberId;
                x.AddressDescriptorId = 0;
                x.AddressDescriptorId = 0;
            }
            context.AddressDescriptors.AddRange(model.AddressDescriptors);
            context.SaveChanges();

            Models.Projects objData = new Projects();
            
            objData.Status = model.Status;
            objData.ProjectType = model.ProjectType;
            objData.DateModified = DateTime.Now;
            objData.DateCreated = DateTime.Now;
            objData.EmployeeId = model.ResourceId;
            objData.ProjectNumberId = obj.ProjectNumberId;
            context.Projects.Add(objData);

            Models.ProjectRevisions objrevison = new Models.ProjectRevisions();
            objrevison.ProjectManagerId = obj.ProjectManagerId;
            objrevison.ProjectDeveloperId = model.ProjectDeveloperId;
            objrevison.ProjectId = objData.ProjectId;
            objrevison.Hours = model.ProjectHours;
            objrevison.ProjectRevisionId = 1;
            context.ProjectRevisions.Add(objrevison);

            return new JsonModel(null, "Save Successfully", (int)HttpStatusCode.OK, "");
        }


        public JsonModel UpdateProjectScheduler(Projects model)
        {
            var project = context.Projects.Where(p => p.ProjectId == model.ProjectId);
           

            if (project != null)
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
            return new JsonModel("", "successfully updated", (int)(HttpStatusCode.OK), "");
        }

        //public JsonModel UpdateProjectScheduler()
        //{


        //    return new JsonModel("", "", (int)(HttpStatusCode.OK), "");
        //}


       public JsonModel DeleteProjectScheduler(int id)
        {
            var project = context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();


            if(project!=null)
            {
                context.Entry(project).State = EntityState.Deleted;
                context.SaveChanges();

            }
            return new JsonModel("", "successfully deleted", (int)(HttpStatusCode.OK), "");
        }

        //public JsonModel GetEventsByFilter(DateTime? startDate, DateTime? endate, int departmentId)
        //{

        //    //var projectList = context.Projects.Where(p=> p.StartDate.Date >= startDate.Value.Date && p.EndDate.Date <= endate.Value.Date && p.DepartmentId==departmentId).Include("Employee").Include("ProjectNumber").Include("ProjectRevisions").Include(p => p.ProjectNumber.ProjectManager).Include(p => p.ProjectNumber.ProjectDeveloper).Include(p => p.ProjectNumber.Location).Include(p=>p.ProjectNumber.Client).ToList();
        //    //return new JsonModel(projectList, "", (int)HttpStatusCode.OK, "");

        //}
      


    }
}
