using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KlamthIrrigationDistrict.DataLayer.DataModels;
using KlamthIrrigationDistrict.DataLayer.Interfaces;
using KlamthIrrigationDistrict.DataLayer.Repositories;
using KlamthIrrigationDistrict.Models;

namespace KlamthIrrigationDistrict.Controllers
{
    public class CustomerHistoryController : Controller
    {
        public ICustomerHistoryRepository _chRepo;
        public CustomerHistoryController()
        {
            _chRepo = new CustomerHistoryRepository();
        }
        // GET: CustomerHistory
        [HttpGet]
        public ActionResult Index()
        {
            return View(_chRepo.GetList());
        }
    }
}