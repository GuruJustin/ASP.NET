using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IEventMangerService
    {
        public List<EventManager> GetEventsManagerList();
        public EventManager GetEventManagerByProjectNumberID(int id);
        public void SaveEventManager(EventManager model);
        public void UpdateEventManager(EventManager model);
        public void DeleteEventManager(int id);
    }
}
