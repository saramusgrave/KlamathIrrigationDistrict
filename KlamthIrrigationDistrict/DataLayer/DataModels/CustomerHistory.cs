using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamthIrrigationDistrict.DataLayer.DataModels
{
    public class CustomerHistory
    {
        public int CustomerHistoryID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public decimal WaterUsage { get; set; }
    }
}