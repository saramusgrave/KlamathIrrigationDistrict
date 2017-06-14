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
        public ActionResult Index()
        {
            return View(_requestRepo.GetList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(new CustomerRequest());
        }

        [HttpGet]
        public ActionResult Edit()
        {
            CustomerRequest request = _requestRepo.CreateDelete();
            return View(request);
        }
        [HttpPost]
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
        [HttpPost]
        public ActionResult Edit(CustomerRequest request)
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