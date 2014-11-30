using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MPaidSalary
    {
        public string id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string SalaryId { get; set; }
        public string MonthPaid { get; set; }
        public string Paid { get; set; }
        public string DatePaid { get; set; }
    }
}