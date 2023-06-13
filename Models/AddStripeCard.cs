
using System;
namespace  Pharmacy.Models.Stripe
{
    public record AddStripeCard(

        string CardNumber,
        string ExpirationYear,
        string ExpirationMonth,
        string Cvc);
}

