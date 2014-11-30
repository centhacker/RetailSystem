using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MPayroll
    {
        public string id { get; set; }
        public string EmpId { get; set; }
        public string SalaryId { get; set; }
        public DateTime DateOfPay { get; set; }

    }
}