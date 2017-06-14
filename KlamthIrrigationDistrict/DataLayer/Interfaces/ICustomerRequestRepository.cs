using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using KlamthIrrigationDistrict.DataLayer.DataModels;

namespace KlamthIrrigationDistrict.DataLayer.Interfaces
{
    public interface ICustomerRequestRepository
    {
        CustomerRequest CreateDelete();
        List<CustomerRequest> GetList();
        CustomerRequest SetWaterTImes(CustomerRequest water );
        void Save(CustomerRequest request);
    }
}