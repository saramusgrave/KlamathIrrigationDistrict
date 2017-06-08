using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using KlamthIrrigationDistrict.DataLayer.DataModels;
using KlamthIrrigationDistrict.DataLayer.Interfaces;
using KlamthIrrigationDistrict.DataLayer.Repositories;
using KlamthIrrigationDistrict.DataLayer;

namespace KlamthIrrigationDistrict.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomersRepository _custRepo;

        public CustomersController()
        {
            _custRepo = new CustomersRepository();
         }
        [HttpGet]
        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.Title = "Klamath Irrigation District";
            ViewBag.Header = "KID Customers";
            return View(_custRepo);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(new Customers());
        }
        [HttpPost]
        public ActionResult Add(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return View(customers);
            }
            _custRepo.Save(customers);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            Customers customers = _custRepo.Get(id);
            return View(customers);
        }
        [HttpPost]
        public ActionResult Edit (Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return View(customers);
            }
            _custRepo.Save(customers);
            return RedirectToAction("Index");
        }
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewCustomers (int id)
        {
            Customers customers = _custRepo.Get(id);
            Customers CustomerModel = new Customers()
            {
                CustomerID = customers.CustomerID,
                CustomerFirstName = customers.CustomerFirstName,
                CustomerLastName = customers.CustomerLastName,
                Address1 = customers.Address1,
                Address2 = customers.Address2,
                City = customers.City,
                State = customers.State,
                Zip = customers.Zip,
                CustomerPhoneNumber = customers.CustomerPhoneNumber,
                CustomerEmail = customers.CustomerEmail,

            };
            return ViewCustomers(id);
        }
    }
}