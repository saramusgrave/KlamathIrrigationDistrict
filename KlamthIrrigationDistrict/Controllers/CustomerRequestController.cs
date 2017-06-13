using KlamthIrrigationDistrict.DataLayer.DataModels;
using KlamthIrrigationDistrict.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamthIrrigationDistrict.Controllers
{
    public class CustomerRequestController : Controller
    {
        private CustomerRequestRepository _requestRepo;
        public CustomerRequestController()
        {
            _requestRepo = new CustomerRequestRepository();
        }
        //Main index, CreateDelete
        [HttpGet]
        public ActionResult Add()
        {
            return View(_requestRepo.CreateDelete());
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View(_requestRepo.CreateDelete());
        }
        [HttpGet]
        public ActionResult Add(CustomerRequest water)
        {
            if(!ModelState.IsValid)
            {
                return View(water);
            }
            _requestRepo.SetWaterTImes(water);
            return RedirectToAction("Index");
        }

        //Save
        [HttpGet]
        public ActionResult Save(CustomerRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
            _requestRepo.Save(request);
            return RedirectToAction("Index");
        }
    }
}