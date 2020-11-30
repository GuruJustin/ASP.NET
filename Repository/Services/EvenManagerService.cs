using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;

namespace Repository.Services
{
   public class EvenManagerService : IEventMangerService
    {
        WesternSchedulerContext _context;
        public EvenManagerService(WesternSchedulerContext context)
        {
            _context = context;
        }
        public void DeleteEventManager(int id)
        {
            var eventManagers = (from ep in _context.Events
                                 join e in _context.ProjectNumbers on ep.ProjectNumberId equals e.ProjectNumberId
                                 join t in _context.Employees on ep.ResourceId equals t.EmployeeId
                                 join p in _context.ProjectDevelopers on e.ProjectDeveloperId equals p.ProjectDeveloperId
                                 join pt in _context.ProjectManagers on e.ProjectManagerId equals pt.ProjectManagerID
                                 join pdx in _context.XProjectDeveloperLocations on e.ProjectDeveloperId equals pdx.ProjectDeveloperId
                                 join pme in _context.XProjectManagerLocations on e.ProjectManagerId equals pme.ProjectManagerID
                                 join lt in _context.Locations on pdx.LocationId equals lt.LocationId
                                 join lmt in _context.Locations on pme.LocationId equals lmt.LocationId
                                 where e.ProjectNumberId == id
                                 select new EventManager
                                 {
                                     Employees = t,
                                     ProjectDevelopers = p,
                                     ProjectManagers = pt,
                                     Events = ep,
                                     ProjectNumbers = e,
                                     LocationsDevelopers = lt,
                                     LocationsManagers = lmt
                                 }).FirstOrDefault();

            var data = _context.ProjectDevelopers.Where(p => p.ProjectDeveloperId == eventManagers.ProjectDevelopers.ProjectDeveloperId);
            if (data != null)
            {
                _context.Entry(eventManagers.ProjectDevelopers).State = EntityState.Deleted;
                _context.SaveChanges();
            }

            var locData = _context.ProjectManagers.Where(p => p.ProjectManagerID == eventManagers.ProjectManagers.ProjectManagerID);
            if (locData != null)
            {
                _context.Entry(eventManagers.ProjectDevelopers).State = EntityState.Deleted;
                _context.SaveChanges();

            }
            var ProjectNumber = _context.ProjectNumbers.Where(p => p.ProjectNumberId == eventManagers.ProjectNumbers.ProjectNumberId);
            if (ProjectNumber != null)
            {
                _context.Entry(eventManagers.ProjectNumbers).State = EntityState.Deleted;
                var Employee = _context.Employees.Where(p => p.EmployeeId == eventManagers.Employees.EmployeeId);
                if (Employee != null)
                {
                    _context.Entry(eventManagers.Employees).State = EntityState.Deleted;
                    _context.SaveChanges();
                }

                var Events = _context.Events.Where(p => p.Id == eventManagers.Events.Id).FirstOrDefault();
                if (Events != null)
                {
                    if (Employee != null)
                    {
                        _context.Entry(eventManagers.Events).State = EntityState.Deleted;
                        _context.SaveChanges();
                    }
                }






            }
        }




        public void UpdateEventManager(EventManager model)
        {
            var data = _context.ProjectDevelopers.Where(p => p.ProjectDeveloperId == model.ProjectDevelopers.ProjectDeveloperId);
            if (data != null)
            {
                _context.Entry(model.ProjectDevelopers).State = EntityState.Modified;
                _context.SaveChanges();
            }

            var locData = _context.ProjectManagers.Where(p => p.ProjectManagerID == model.ProjectManagers.ProjectManagerID);
            if(locData!=null)
            {
                _context.Entry(model.ProjectDevelopers).State = EntityState.Modified;
                _context.SaveChanges();

            }
            var ProjectNumber = _context.ProjectNumbers.Where(p => p.ProjectNumberId == model.ProjectNumbers.ProjectNumberId);
            if(ProjectNumber!=null)
            {
                _context.Entry(model.ProjectNumbers).State = EntityState.Modified;
                _context.SaveChanges();

            }
            var Employee = _context.Employees.Where(p => p.EmployeeId == model.Employees.EmployeeId);
            if(Employee!=null)
            {
                _context.Entry(model.Employees).State = EntityState.Modified;
                _context.SaveChanges();
            }

            var Events = _context.Events.Where(p => p.Id == model.Events.Id).FirstOrDefault();
            if(Events!=null)
            {
                if (Employee != null)
                {
                    _context.Entry(model.Events).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }

        public void SaveEventManager(EventManager model)
        {
            _context.ProjectDevelopers.Add(model.ProjectDevelopers);
            _context.Locations.Add(model.LocationsDevelopers);
            _context.Locations.Add(model.LocationsManagers);
            model.XProjectDeveloperLocations.LocationId = model.LocationsDevelopers.LocationId;
            model.XProjectManagerLocations.LocationId = model.LocationsManagers.LocationId;

            _context.ProjectManagers.Add(model.ProjectManagers);
            _context.SaveChanges();

             model.XProjectDeveloperLocations.ProjectDeveloperId = model.ProjectDevelopers.ProjectDeveloperId;
            _context.XProjectDeveloperLocations.Add(model.XProjectDeveloperLocations);
            _context.XProjectManagerLocations.Add(model.XProjectManagerLocations);

             model.XProjectManagerLocations.ProjectManagerID=model.ProjectManagers.ProjectManagerID;
            _context.ProjectNumbers.Add(model.ProjectNumbers);
            _context.SaveChanges();

            _context.Employees.Add(model.Employees);
            model.Events.ProjectNumberId = model.ProjectNumbers.ProjectNumberId;
            model.Events.ResourceId = model.Employees.EmployeeId;
            _context.Events.Add(model.Events);
            _context.SaveChanges();
        }




        public EventManager GetEventManagerByProjectNumberID(int id)
        {
            var eventManagers = (from ep in _context.Events
                                 join e in _context.ProjectNumbers on ep.ProjectNumberId equals e.ProjectNumberId
                                 join t in _context.Employees on ep.ResourceId equals t.EmployeeId
                                 join p in _context.ProjectDevelopers on e.ProjectDeveloperId equals p.ProjectDeveloperId
                                 join pt in _context.ProjectManagers on e.ProjectManagerId equals pt.ProjectManagerID
                                 join pdx in _context.XProjectDeveloperLocations on e.ProjectDeveloperId equals pdx.ProjectDeveloperId
                                 join pme in _context.XProjectManagerLocations on e.ProjectManagerId equals pme.ProjectManagerID
                                 join lt in _context.Locations on pdx.LocationId equals lt.LocationId
                                 join lmt in _context.Locations on pme.LocationId equals lmt.LocationId
                                 where e.ProjectNumberId == id
                                 select new EventManager
                                 {
                                     Employees = t,
                                     ProjectDevelopers = p,
                                     ProjectManagers = pt,
                                     Events = ep,
                                     ProjectNumbers = e,
                                     LocationsDevelopers = lt,
                                     LocationsManagers = lmt
                                 }).FirstOrDefault();


            return eventManagers;

        }

        public List<EventManager> GetEventsManagerList()
        {

            //_context.ProjectNumbers.ToList();
            var eventManagers = (from ep in _context.Events
                                 join e in _context.ProjectNumbers on ep.ProjectNumberId equals e.ProjectNumberId
                                 join t in _context.Employees on ep.ResourceId equals t.EmployeeId
                                 join p in _context.ProjectDevelopers on e.ProjectDeveloperId equals p.ProjectDeveloperId
                                 join pt in _context.ProjectManagers on e.ProjectManagerId equals pt.ProjectManagerID
                                 join pdx in _context.XProjectDeveloperLocations on e.ProjectDeveloperId equals pdx.ProjectDeveloperId
                                 join pme in _context.XProjectManagerLocations on e.ProjectManagerId equals pme.ProjectManagerID
                                 join lt in _context.Locations on pdx.LocationId equals lt.LocationId
                                 join lmt in _context.Locations on pme.LocationId equals lmt.LocationId
                                 //where e.OwnerID == user.UID
                                 select new EventManager
                                 {
                                     Employees = t,
                                     ProjectDevelopers = p,
                                     ProjectManagers = pt,
                                     Events = ep,
                                     ProjectNumbers = e,
                                     LocationsDevelopers = lt,
                                     LocationsManagers = lmt
                                 }).ToList(); 


            return eventManagers;
        }

    }
}
