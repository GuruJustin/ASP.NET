using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class CommonServices : ICommonServices
    {
        WesternSchedulerContext _context;
        public CommonServices(WesternSchedulerContext context)
        {
            _context = context;
        }

        public List<ListOfValues> GetListOfValues()
        {
            return _context.ListOfValues.ToList();
        }
        
    }
}
