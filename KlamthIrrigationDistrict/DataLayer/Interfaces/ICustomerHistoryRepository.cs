using KlamthIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamthIrrigationDistrict.DataLayer.Interfaces
{
    public interface ICustomerHistoryRepository
    {
        List<CustomerHistory> GetList();
    }
}