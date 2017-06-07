using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamthIrrigationDistrict.DataLayer
{
    public class CustomerRequest
    {
        public int RequestID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public decimal WaterAmount { get; set; }
        public DateTime WaterOnDate { get; set; }
        public DateTime WaterOffDate { get; set; }
        public string Comments { get; set; }
        public int DitchRiderID { get; set; }
        public DateTime WaterOn { get; set; }
        public DateTime WaterOff { get; set; }
    }
}