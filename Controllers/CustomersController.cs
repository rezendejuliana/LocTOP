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
            var viewModel = new NewCustomerViewModel() { MembershipType = membershipTypes};
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

    }
}