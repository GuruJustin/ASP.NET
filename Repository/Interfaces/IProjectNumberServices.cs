using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IProjectNumberServices
    {
        public List<ProjectNumbers> GetProjectNumberList();

        public ProjectNumbers GetProjectNumberById(int Id);

        public ProjectNumbers SaveProjectNumber(ProjectNumbers model);

        public void UpdateProjectNumber(ProjectNumbers model);

        public void DeleteProjectNumber(int id);

    }
}
