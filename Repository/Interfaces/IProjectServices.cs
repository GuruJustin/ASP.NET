using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public  interface IProjectServices
    {
        public List<Projects> GetProjectList();

        public Projects GetProjectById(int Id);

        public Projects SaveProject(Projects model);

        public void UpdateProject(Projects model);

        public void DeleteProject(int id);


    }
}
