using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class ProjectNumberServices :  IProjectNumberServices
    {
        WesternSchedulerContext _context;
        public ProjectNumberServices(WesternSchedulerContext context)
        {
            _context = context;
        }

       public List<ProjectNumbers> GetProjectNumberList()
        {
            return _context.ProjectNumbers.Include("Client").Include("Location").Include("ProjectDeveloper").Include("ProjectManager").Include("AddressDescriptors").Include("Projects").Include("Events").ToList();
        }

        public ProjectNumbers GetProjectNumberById(int id)
        {
            return _context.ProjectNumbers.Where(p => p.ProjectNumberId == id).Include("Client").Include("Location").Include("ProjectDeveloper").Include("ProjectManager").Include("AddressDescriptors").Include("Projects").Include("Events").FirstOrDefault();
        }

        public ProjectNumbers SaveProjectNumber(ProjectNumbers model)
        {
            _context.ProjectNumbers.Add(model);
            _context.SaveChanges();
            return model;
        }


        public void UpdateProjectNumber(ProjectNumbers model)
        {
            var list = _context.ProjectNumbers.Where(p => p.ProjectNumberId == model.ProjectNumberId).FirstOrDefault();

            if (list != null)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }

        }

        public void DeleteProjectNumber(int id)
        {
            var list = _context.ProjectNumbers.Where(p => p.ProjectNumberId == id).FirstOrDefault();

            if(list!=null)
            {
                _context.Entry(list).State = EntityState.Deleted;
                _context.SaveChanges();
            }

        }

    }
}
