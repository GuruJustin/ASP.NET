using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.ViewModel;

namespace WesternSchedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerInfoController:ControllerBase
    {
        ISchedulerInfoServices _services;
        public SchedulerInfoController(ISchedulerInfoServices services)
        {
            _services = services; 
        }

        [HttpGet]
        [Route("GetInfo")]
        public JsonModel Get()
        {
            return _services.GetSchedulerInfoList();
        }

    }
}
