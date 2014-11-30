using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MJournal
    {
        public string id { get; set; }
        public string acc_id { get; set; }
        public string amount { get; set; }
        public string des { get; set; }
        public string type { get; set; }
        public string e_date { get; set; }

    }
}