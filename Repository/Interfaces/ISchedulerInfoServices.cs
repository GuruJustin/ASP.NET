using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
   public interface ISchedulerInfoServices
    {
        public JsonModel GetSchedulerInfoList();
        //public SchedulerInfo GetSchedulerInfoByProjectNumberID(int id);
        //public void SaveSchedulerInfo(SchedulerInfo model);
        //public void UpdateSchedulerInfo(SchedulerInfo model);
        //public void DeleteSchedulerInfo(int id);

    }
}
