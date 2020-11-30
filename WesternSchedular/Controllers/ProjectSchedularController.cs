using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WesternSchedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectSchedularController : ControllerBase
    {
        // GET: api/<ProjectSchedularController>
        IProjectScheduler services;
        public ProjectSchedularController(IProjectScheduler _services)
        {
            services = _services;
        }

        [HttpGet]
        public JsonModel Get()
        {
            return services.GetProjectSchedulerList();
        }

        // GET api/<ProjectSchedularController>/5
        [HttpGet("{id}")]
        public JsonModel Get(int id)
        {
            return services.GetProjectSchedulerById(id);
        }

        // POST api/<ProjectSchedularController>
        [HttpPost]
        public JsonModel Post([FromBody] ProjectScheduleViewModel value)
        {
            return services.SaveProjectScheduler(value);
        }

        // PUT api/<ProjectSchedularController>/5
        [HttpPut("{id}")]
        public JsonModel Put(int id, [FromBody] Projects value)
        {
            return services.UpdateProjectScheduler(value);
        }

        // DELETE api/<ProjectSchedularController>/5
        [HttpDelete("{id}")]
        public JsonModel Delete(int id)
        {
            return services.DeleteProjectScheduler(id);
        }

        //[HttpGet]
        //[Route("GetEvents")]
        //public JsonModel GetEvents(DateTime? startDate, DateTime? endDate, int departmentId)
        //{
        //    return services.GetEventsByFilter(startDate, endDate, departmentId);
        //}

    }
}
