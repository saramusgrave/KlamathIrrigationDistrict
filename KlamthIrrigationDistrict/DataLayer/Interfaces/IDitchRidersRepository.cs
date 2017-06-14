using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using KlamthIrrigationDistrict.DataLayer.DataModels;

namespace KlamthIrrigationDistrict.DataLayer.Interfaces
{
    public interface IDitchRidersRepository
    {
        DitchRider Get(int id);
        List<DitchRider> GetList();
        void Save(DitchRider rider);
    }
}