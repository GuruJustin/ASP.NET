using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public  interface ICommonServices
    {
        public List<ListOfValues> GetListOfValues();
    }
}
