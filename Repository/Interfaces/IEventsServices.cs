using Repository.Models;

using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public  interface IEventsServices
    {
        public List<Repository.Models.Events> GetEvents();

        public  Repository.Models.Events GetEventById(int Id);

        public void SaveEvent(Repository.Models.Events model);

        public void UpdateEvent(Repository.Models.Events model);

        public void DeleteEvent(int id);

        public JsonModel GetEventsByFilter(DateTime? startDate, DateTime? endDate, int departmentId);

    }
}
