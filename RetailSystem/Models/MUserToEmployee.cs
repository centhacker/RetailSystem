using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MUserToEmployee
    {
        public int id { get; set; }
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
    }
}