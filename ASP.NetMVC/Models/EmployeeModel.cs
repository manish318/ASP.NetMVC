using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NetMVC.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string PhoneNo { get; set; }
    }
}