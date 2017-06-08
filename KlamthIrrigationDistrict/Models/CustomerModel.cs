using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlamthIrrigationDistrict.DataLayer.DataModels;

namespace KlamthIrrigationDistrict.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
    }
}