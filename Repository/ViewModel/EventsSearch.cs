using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
   public  class EventsSearch
    {
        public string ClientName { get; set; }

        public string ProjectNumber { get; set; }

    }

    public class ClientSearch
    {
        public string Name { get; set; }

        public int ? ClientId { get; set; }
    }


    public class  ProjectSearch
    {
        public string Name { get; set; }

        public int ProjectNumberId { get; set; }
    }

    public class SerchModel
    {
        public int ProjectNumberId { get; set; }
        public string ClientName { get; set; }
        public int DepartmentId { get; set; }
    }

    public class EventResponseModel
    {
        public EventResponseModel()
        {
            this.EventInfo =new  List<EventIntialInfo>();
        }
        public object ProjectReviewList { get; set; }
        public List<EventIntialInfo> EventInfo { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }



    public enum ProjectStatus
    {
        Active=1,
        Closed=2,
        Pending=3,
        Verified=4
    }

    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string Status { get; set; }
    }

    public class RevisionInfoModel
    {
        public int RevisionId { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ResourceId { get; set; }

    }
}
