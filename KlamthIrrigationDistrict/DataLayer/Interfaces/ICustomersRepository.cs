using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using KlamthIrrigationDistrict.DataLayer.DataModels;

namespace KlamthIrrigationDistrict.DataLayer.Interfaces
{
   public interface ICustomersRepository
    {
        Customers Get(int id);
        List<Customers> GetList();
        void Save(Customers customers);
    }
}