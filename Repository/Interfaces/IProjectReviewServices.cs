using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public interface IProjectReviewServices
    {

        public JsonModel GetProjectReviewSchedulerList();

        public JsonModel GetProjectReviewSchedulerById(int Id);

        public JsonModel SaveProjectScheduler(ProjectScheduleViewModel model);

        public JsonModel SaveProjectSchedulerWithProjectNumber(ProjectScheduleViewModel model);

        public JsonModel UpdateProjectReviewScheduler(ProjectScheduleViewModel model);

        public JsonModel DeleteProjectScheduler(int id);

        public JsonModel DeleteProjectSchedulerWithProjectNumber(int id);
    
       public JsonModel GetEventsByFilter(DateTime? startDate, DateTime? endDate, int departmentId);

        public JsonModel GetEventByRevisionId(int revisonid);

       public JsonModel SaveProjectSchedularOffDay(ProjectScheduleViewModel model);
        public JsonModel UpdateProjectSchedularOffDay(ProjectScheduleViewModel model);
        public JsonModel FilterSuggestion(string search);
        public JsonModel EventSearchByFilter(SerchModel search);
        public JsonModel ChangeProjectStatus(ProjectModel projectStatus);
        public JsonModel SplitProjectRevision(int projectRevisionId);
        public JsonModel DuplicateProjectRevision(int projectRevisionId);
        public JsonModel AlterRevision(RevisionInfoModel model);

    }
}
