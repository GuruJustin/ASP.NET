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
  public  class EventServices : IEventsServices
    {
       private WesternSchedulerContext _context;
        public EventServices(WesternSchedulerContext context)
        {
            _context = context;
        }
        public List<Repository.Models.Events> GetEvents()
        {
            return _context.Events.Include("Resource").Include("ProjectNumbers").ToList();
        }

         public Repository.Models.Events  GetEventById(int id)
        {

            return _context.Events.FirstOrDefault(p => p.Id == id);
        }

        public void SaveEvent(Repository.Models.Events model)
        {
            _context.Events.Add(model);
            _context.SaveChanges();
            _context.ProjectNumbers.Add(model.ProjectNumbers);
            _context.SaveChanges();
        }

        public void UpdateEvent(Repository.Models.Events model)
        {
            var list = _context.Events.Where(p => p.Id == model.Id).FirstOrDefault();

            if(list!=null)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }


        }

        public void  DeleteEvent(int id)
        {
            var list = _context.Events.Where(p => p.Id == id).FirstOrDefault();


            if(list!=null)
            {

                _context.Events.Remove(list);
                _context.SaveChanges();
            }
        }


        public JsonModel GetEventsByFilter(DateTime? startDate, DateTime?endate, int departmentId)
        {

            var eventList = _context.Events.Where(p=>p.StartDate.Value.Date>=startDate.Value.Date && p.EndDate.Value.Date<=endate.Value.Date).Include("Resource").Include("ProjectNumbers").Include(p=>p.ProjectNumbers.AddressDescriptors).Include(p => p.ProjectNumbers.Client).Include(p => p.ProjectNumbers.Location).Include(p => p.ProjectNumbers.ProjectDeveloper).Include(p => p.ProjectNumbers.ProjectManager).Include(p => p.ProjectNumbers.Projects).ToList();
            return new JsonModel(eventList, "", (int)HttpStatusCode.OK, "");

        }





    }
}
