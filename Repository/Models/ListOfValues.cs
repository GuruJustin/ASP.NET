using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ListOfValues
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
