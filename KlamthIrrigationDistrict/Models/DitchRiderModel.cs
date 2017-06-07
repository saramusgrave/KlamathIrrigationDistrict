using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlamthIrrigationDistrict.DataLayer.DataModels;

namespace KlamthIrrigationDistrict.Models
{
    public class DitchRiderModel
    {
        public int DitchRiderID { get; set; }
        public string DitchRiderFirstName { get; set; }
        public string DitchRiderLastname { get; set; }
        public int DitchRiderPhoneNumber { get; set; }
    }
}