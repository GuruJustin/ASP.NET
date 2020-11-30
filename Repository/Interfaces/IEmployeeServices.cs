using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IEmployeeServices
    {
        public List<Employees> GetEmployeesList();

        public Employees GetEmployeeById(int Id);

        public void SaveEmployee(Employees model);

        public void UpdateEmployee(Employees model);

        public void DeleteEmployee(int id);

        public JsonModel GetEmployeeByClient(string ClientName);
        

    }
}
