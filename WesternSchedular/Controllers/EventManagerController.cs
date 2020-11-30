using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;

namespace WesternSchedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventManagerController : ControllerBase
    {
        IEventMangerService _services;
       public EventManagerController(IEventMangerService services)
        {
            _services = services;
        }

        [HttpGet]
        public IEnumerable<EventManager> Get()
        {
            return _services.GetEventsManagerList();
        }

        [HttpGet("{id}")]
        public EventManager Get(int id)
        {
            return _services.GetEventManagerByProjectNumberID(id);
        }

        [HttpPost]
        public void Post([FromBody] EventManager value)
        {
            try
            {
                _services.SaveEventManager(value);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public void Put(EventManager value)
        {
            try
            {
                _services.UpdateEventManager(value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _services.DeleteEventManager(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
