
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Contracts;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models.Stripe;
using Pharmacy.Models.Stripe.Pharmacy.Models.Stripe;

namespace  Pharmacy.Controllers
{
    [Route("api/[controller]")]
    public class StripeController : Controller
    {
        private readonly IStripeAppService _stripeService;

        public StripeController(IStripeAppService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("/api/customer/add")] // Rruga për shtimin e klientit
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer(
    [FromBody] AddStripeCustomer customer,
    CancellationToken ct)
        {
            StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(
                customer,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }

        [HttpPost("/api/payment/add")] // Rruga për shtimin e pagesës
        public async Task<ActionResult<StripePayment>> AddStripePayment(
    [FromBody] AddStripePayment payment,
    CancellationToken ct)
        {
            StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(
                payment,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdPayment);
        }
    }
}
