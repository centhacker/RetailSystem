using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MFiscalYear
    {
        public int id { get; set; }
        public DateTime fiscalFrom { get; set; }
        public DateTime fiscalTo { get; set; }
    }
}