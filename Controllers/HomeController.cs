using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace StripeDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Charge(string  stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions {
              Email = stripeEmail,
              SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions {
              Amount = 500,
              Description = "Sample Charge",
              Currency = "usd",
              CustomerId = customer.Id
            });

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
