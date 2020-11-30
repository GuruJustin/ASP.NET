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
    public class CommonController : ControllerBase
    {
        ICommonServices _commonServices;
        public CommonController(ICommonServices commonServices)
        {
            _commonServices = commonServices;

        }

         // GET: api/<CommonController>
        [HttpGet]
        public List<ListOfValues> ListOfValues()
        {
            return _commonServices.GetListOfValues();
        }

    }
}
