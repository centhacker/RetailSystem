using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MClients
    {
        public int id { get; set; }
        public string ClientTypeld { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public bool isVendor { get; set; }
        public string edate { get; set; }
        public string WareHouseId { get; set; }
        public string NIC { get; set; }
        public string GrantorName { get; set; }
        public string GrantorNIC { get; set; }


    }
}