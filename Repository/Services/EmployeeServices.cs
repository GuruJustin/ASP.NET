using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
  public  class EmployeeServices : IEmployeeServices
    {
        private WesternSchedulerContext _context;
        public EmployeeServices(WesternSchedulerContext context)
        {
            _context = context;
        }
      
        public List<Employees> GetEmployeesList()
        {

           return _context.Employees.ToList();
        }

        public  JsonModel  GetEmployeeByClient(string name)
        {

            //var list=(from ab in _context.Employees e
            //          join abc in _context.Projects pj on e.
            //          )

            var list = (from emp in _context.Employees
                        join proj in _context.Projects on emp.EmployeeId equals proj.EmployeeId
                        join projNumber in _context.ProjectNumbers on proj.ProjectNumberId equals projNumber.ProjectNumberId
                        join client in _context.Clients on projNumber.ClientId equals client.ClientId
                        where client.ClientName == name
                        select emp
                        );

           //var employeeId=   _context.Employees.FirstOrDefault(p =>p.);
            return new JsonModel(list, "", (int)HttpStatusCode.OK, "");

        }

        public Employees GetEmployeeById(int id)
        {

            return _context.Employees.FirstOrDefault(p => p.EmployeeId == id);
        }

        public void SaveEmployee(Employees model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employees model)
        {
            var list = _context.Employees.Where(p => p.EmployeeId== model.EmployeeId).FirstOrDefault();

            if (list != null)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }


        }

        public void DeleteEmployee(int id)
        {
            var list = _context.Employees.Where(p => p.EmployeeId == id).FirstOrDefault();


            if (list != null)
            {

                _context.Employees.Remove(list);
                _context.SaveChanges();
            }
        }


    }
}
