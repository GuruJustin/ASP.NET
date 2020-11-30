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
    public class ProectNumberController : ControllerBase
    {
        IProjectNumberServices _projectNumberServices;
        public ProectNumberController(IProjectNumberServices projectNumberServices)
        {
            _projectNumberServices = projectNumberServices;
        }

        // GET: api/<ProectNumberController>
        [HttpGet]
        public List<ProjectNumbers> Get()
        {
            return _projectNumberServices.GetProjectNumberList();
        }

        // GET api/<ProectNumberController>/5
        [HttpGet("{id}")]
        public ProjectNumbers Get(int id)
        {
            return _projectNumberServices.GetProjectNumberById(id);
        }

        // POST api/<ProectNumberController>
        [HttpPost]
        public void Post([FromBody] ProjectNumbers value)
        {
             _projectNumberServices.SaveProjectNumber(value);
        }

        // PUT api/<ProectNumberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProjectNumbers value)
        {
            _projectNumberServices.UpdateProjectNumber(value);
        }

        // DELETE api/<ProectNumberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _projectNumberServices.DeleteProjectNumber(id);
        }
    }
}
