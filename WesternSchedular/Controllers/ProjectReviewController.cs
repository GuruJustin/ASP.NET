using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Services;
using Repository.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WesternSchedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectReviewController : ControllerBase
    {
        // GET: api/<ProjectReviewController>

        private IProjectReviewServices projectReviewServices;

        public ProjectReviewController(IProjectReviewServices _projectReviewServices)
        {
            projectReviewServices = _projectReviewServices;
        }

        [HttpGet]
        [Route("ProjectReviewDetail")]
        public JsonModel Get()
        {
            return projectReviewServices.GetProjectReviewSchedulerList();
        }

        // GET api/<ProjectReviewController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectReviewController>
        [HttpPost]
        public JsonModel Post([FromBody]  ProjectScheduleViewModel value)
        {
            return projectReviewServices.SaveProjectScheduler(value);
        }

        // PUT api/<ProjectReviewController>/5
        [HttpPut]
        public JsonModel Put([FromBody] ProjectScheduleViewModel value)
        {
           return projectReviewServices.UpdateProjectReviewScheduler(value);
        }

        // DELETE api/<ProjectReviewController>/5
        [HttpDelete("{id}")]
        public JsonModel Delete(int id)
        {
            return projectReviewServices.DeleteProjectScheduler(id);
        }

        [HttpGet]
        [Route("GetEvents")]
        public JsonModel GetEvents(DateTime ? startDate, DateTime ? endDate, int departmentId)
        {
            var list = projectReviewServices.GetEventsByFilter(startDate, endDate,departmentId);
            return list;
        }

        [HttpGet]
        [Route("GetFilterSuggestion")]
        public JsonModel GetFilterSuggestion(string search)
        {
            var list = projectReviewServices.FilterSuggestion(search);
            return list;
        }

        [HttpPost]
        [Route("GetEventsBySearchFilter")]
        public JsonModel GetEventsBySearch([FromBody] SerchModel search)
        {
            var list = projectReviewServices.EventSearchByFilter(search);
            return list;
        }

        [HttpPost]
        [Route("UpdateProjectSatatus")]
        public JsonModel UpdateProjectSatus([FromBody] ProjectModel value)
        {
            return projectReviewServices.ChangeProjectStatus(value);
        }


        [HttpPost]
        [Route("SaveRevisionWithProjectNumber")]
        public JsonModel SaveRevisionWithProjectNumber([FromBody] ProjectScheduleViewModel value)
        {
            return projectReviewServices.SaveProjectSchedulerWithProjectNumber(value);
        }

        [HttpPost]
        [Route("SaveOffDay")]
        public JsonModel SaveOutOfOfficeDetail([FromBody] ProjectScheduleViewModel value)
        {
            var list = projectReviewServices.SaveProjectSchedularOffDay(value);
            return list;
        }
        [HttpGet]
        [Route("GetEventByRevisionId")]
        public JsonModel GetEventByRevisionId(int id)
        {
            var list = projectReviewServices.GetEventByRevisionId(id);
            return list;
        }
        [HttpGet]
        [Route("SplitProjectRevision")]
        public JsonModel SplitProjectRevision(int projectRevisionId)
        {
            var list = projectReviewServices.SplitProjectRevision(projectRevisionId);
            return list;
        }
        [HttpGet]
        [Route("DuplicateProjectRevision")]
        public JsonModel DuplicateProjectRevision(int projectRevisionId)
        {
            var list = projectReviewServices.DuplicateProjectRevision(projectRevisionId);
            return list;
        }
        
        [HttpPost]
        [Route("AlterRevision")]
        public JsonModel AlterRevision([FromBody] RevisionInfoModel value)
        {
            var result = projectReviewServices.AlterRevision(value);
            return result;
        }

        

        [HttpPost]
        [Route("UpdateOffDay")]
        public JsonModel UpdateOutOfDetail([FromBody] ProjectScheduleViewModel value)
        {
            var list = projectReviewServices.UpdateProjectSchedularOffDay(value);
            return list;
        }


    }
}
