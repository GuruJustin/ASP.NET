using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public interface IProjectScheduler
    {

        public JsonModel GetProjectSchedulerList();

        public JsonModel GetProjectSchedulerById(int Id);

        public JsonModel SaveProjectScheduler(ProjectScheduleViewModel model);

       public JsonModel UpdateProjectScheduler(Projects model);

       public JsonModel DeleteProjectScheduler(int id);

      //public JsonModel GetEventsByFilter(DateTime? startDate, DateTime? endDate, int departmentId);




    }
}
