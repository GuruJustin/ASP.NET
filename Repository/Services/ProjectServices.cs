using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class ProjectServices : IProjectServices
    {
        WesternSchedulerContext _context;
        public ProjectServices(WesternSchedulerContext context)
        {
            _context = context;
        }

        public List<Projects> GetProjectList()
        {
            return _context.Projects.Include("Employee").Include("ProjectNumber").Include("ProjectRevisions").ToList();
        }

        public Projects GetProjectById(int id)
        {
            return _context.Projects.Where(p => p.EmployeeId == id).Include("Employee").Include("ProjectNumber").Include("ProjectRevisions").FirstOrDefault();
        }

       public  Projects SaveProject(Projects model)
        {
            model.DateCreated = DateTime.Now;
            _context.Projects.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteProject(int  id)
        {

            var projectModel = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();

            if(projectModel!=null)
            {
                _context.Projects.Remove(projectModel);
                _context.SaveChanges();
            }

        }

        public void UpdateProject(Projects model)
        {
            var projectModel = _context.Projects.Where(p => p.ProjectId == model.ProjectId).FirstOrDefault();
            if(projectModel!=null)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }


            

    }
}
