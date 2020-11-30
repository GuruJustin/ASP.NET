using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;

namespace WesternSchedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventsServices _eventsServices;
        public EventsController(IEventsServices eventsServices)
        {
            _eventsServices = eventsServices;
        }
        [HttpGet]
        [Route("Events")]
        public List<Repository.Models.Events> GetEvents()
        {
            return _eventsServices.GetEvents();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Repository.Models.Events Get(int id)
        {
            return _eventsServices.GetEventById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Repository.Models.Events value)
        {
            try
            {
                _eventsServices.SaveEvent(value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Repository.Models.Events value)
        {
            try
            {
                _eventsServices.UpdateEvent(value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _eventsServices.DeleteEvent(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetEvents")]
        public JsonModel GetEvents(DateTime ? startDate, DateTime ?endDate, int departmentId)
        {
            return _eventsServices.GetEventsByFilter(startDate,endDate,departmentId);
        }


    }
}
