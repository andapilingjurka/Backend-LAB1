
using System;
using Pharmacy.Models.Stripe;
using Pharmacy.Models.Stripe.Pharmacy.Models.Stripe;

namespace Pharmacy.Contracts
{
    public interface IStripeAppService
    {
        Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
    }
}
