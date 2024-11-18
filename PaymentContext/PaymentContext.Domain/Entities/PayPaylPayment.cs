
namespace PaymentContext.Domain.Entities
{
    public class PayPaylPayment : Payment
    {
        public PayPaylPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email) : 
            base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
        {
        }

        public string TransactionCode { get; private set; }
    }
}
