using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Models;

namespace WesternSchedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeServices _employeeServices;
      
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        [HttpGet]
        public List<Employees> Get()
        {
           return _employeeServices.GetEmployeesList();
        }

        [HttpGet("{id}")]
        public Employees Get(int id)
        {
            return _employeeServices.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employees value)
        {
            try
            {
                _employeeServices.SaveEmployee(value);
            }
            catch(Exception ex)
            {
                throw ex;
             }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Employees value)
        {
            try
            {
                _employeeServices.UpdateEmployee(value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _employeeServices.DeleteEmployee(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<EmployeeController>/5
       
        [HttpGet()]
        [HttpGet]
       [Route("GetEmployee")]
        public void EmployeeByClientName(string name)
        {
            try
            {
                _employeeServices.GetEmployeeByClient(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
