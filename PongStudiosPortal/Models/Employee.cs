using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PongStudiosPortal.Models
{
    public class Employee: Person
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int PreviousEmployeeId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AddressInformation { get; set; }
        public string Region { get; set; }
        public int CountryId { get; set; }
        public int EmployeeTypeId { get; set; }

        [DefaultValue(1)]
        public bool Enabled { get; set; }

        public DateTime HireDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
