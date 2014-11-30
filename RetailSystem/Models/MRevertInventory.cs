using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Models
{
    public class MRevertInventory
    {
        public class RevertConfirm
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string Price { get; set; }
            public string Units { get; set; }
          
        }
    }
}