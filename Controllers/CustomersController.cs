using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Details(int id)
        {
            var CustomerDetail = new Customer ();
            var customers = _context.Customers;
            foreach(var customer in customers)
            {
                if (customer.Id == id)
                {
                    CustomerDetail = customer;
                }
            }
            return View(CustomerDetail);
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //GET
            var ListOfCustomers = new ListOfCustomersMovieViewModel() { Customers = customers };
            return View(ListOfCustomers);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipType = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 1) 
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                //Mapper.Map(customerinDb,customer);  class UpdateCustomerDso
                customerinDb.Name = customer.Name;
                customerinDb.BirthDate = customer.BirthDate;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); //GET
            if (customer == null)
                HttpNotFound();
            var viewModel = new CustomerFormViewModel //ctrl r r
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            
            };
            return View("CustomerForm",viewModel);
        }

    }
}