using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class ListOfCustomersMovieViewModel
    {
        public int Id;
        public List<Customer> Customers { get; set; }

    }
}