
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPaylPayment : Payment
    {
        public PayPaylPayment(string TransactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email) : 
            base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
        {
            TransactionCode = TransactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}
