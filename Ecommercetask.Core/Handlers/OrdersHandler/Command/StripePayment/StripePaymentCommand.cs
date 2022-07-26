using MediatR;
using Stripe;
using Stripe.Infrastructure;

namespace Ecommercetask.Core.Handlers.OrdersHandler.Command.StripePayment
{
    public class StripePaymentCommand : IRequest<string>
    {
        public StripeToken stripeToken { get; set; }
    }

    public class StripePaymentHandler : IRequestHandler<StripePaymentCommand, string>
    {
        public async Task<string> Handle(StripePaymentCommand request, CancellationToken cancellationToken)
        {
            var customers = new CustomerService();
            var customer = customers.Create(new CustomerCreateOptions { 
                Email = request.stripeToken.email,
                Source = request.stripeToken.id,
            });
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long?)(decimal)((request.stripeToken.amount) * 100),
                Currency = "inr",
                Description = "Software development services",
                PaymentMethod = "pm_card_visa"
            };
            var service = new PaymentIntentService();
            service.Create(options);
            return string.Empty;
        }
    }

    public class StripeToken
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public int exp_year { get; set; }
        public int exp_month { get; set; }
        public int cvc { get; set; }
        public decimal amount { get; set; }
    }
}