using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Adname { get; set; }
        public short AccessLevel { get; set; }
    }
}
