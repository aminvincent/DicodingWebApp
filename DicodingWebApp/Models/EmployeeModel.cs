using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DicodingWebApp.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}