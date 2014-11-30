using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MEmployees
    {
        public string id { get; set; }
        public string DesignationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string HomePhone { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }
        public string EmergencyContactNo { get; set; }
        public string WareHouseId { get; set; }
    }
}