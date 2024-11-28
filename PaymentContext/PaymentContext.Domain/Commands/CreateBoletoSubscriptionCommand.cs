using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : ICommand
{
    public string FisrtName { get; private set;}
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
    public string PaymentNumber { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; private set; }
    public string PayerEmail { get; private set; }
    public string PayerDocument { get; private set; }
    public EDocumentType PayerDocumentType { get; private set; }
    public string Street { get; private set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}