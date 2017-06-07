using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamthIrrigationDistrict.DataLayer.Interfaces
{
    public interface ICustomerRequestRepository
    {
        CustomerRequest CreateDelete();
        CustomerRequest SetWaterTImes();
        void Save(CustomerRequest request);
    }
}