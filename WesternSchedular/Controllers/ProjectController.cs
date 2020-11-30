using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WesternSchedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectServices _projectServices;
        public ProjectController(IProjectServices projectServices)
        {
            _projectServices = projectServices;

        }

         // GET: api/<ProjectController>
        [HttpGet]
        public List<Projects> Get()
        {
            return _projectServices.GetProjectList();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Projects Get(int id)
        {
            return _projectServices.GetProjectById(id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public Projects Post([FromBody] Projects value)
        {
            return _projectServices.SaveProject(value);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Projects value)
        {
             _projectServices.UpdateProject(value);
          
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projectServices.DeleteProject(id);

        }
    }
}
