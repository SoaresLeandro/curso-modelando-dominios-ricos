using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreatePayPalSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FisrtName { get;  set;}
    public string LastName { get;  set; }
    public string Document { get;  set; }
    public string Email { get;  set; }
    public string TransactionCode { get;  set; }
    public string PaymentNumber { get;  set; }
    public DateTime PaidDate { get;  set; }
    public DateTime ExpireDate { get;  set; }
    public decimal Total { get;  set; }
    public decimal TotalPaid { get;  set; }
    public string Payer { get;  set; }
    public string PayerEmail { get;  set; }
    public string PayerDocument { get;  set; }
    public EDocumentType PayerDocumentType { get;  set; }
    public string Street { get;  set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreatePayPalSubscriptionCommand>()
            .Requires()
            .IsGreaterThan(FisrtName, 3, "Name.FirstName", "O Nome deve ter pelo menos 3 caracteres.")
            .IsGreaterThan(LastName, 3, "Name.LastName", "O Sobrenome deve ter pelo menos 3 caracteres.")
        );
    }
}