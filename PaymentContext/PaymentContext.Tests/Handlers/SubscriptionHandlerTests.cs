using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FisrtName = "FirstName";
        command.LastName = "LastName";
        command.Document = "99999999999";
        command.Email = "teste@dominio.com";
        command.BarCode = "0123456789";
        command.BoletoNumber = "0000001";
        command.PaymentNumber = "01";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 1000;
        command.TotalPaid = 100;
        command.Payer = "Payer";
        command.PayerDocument = "989898989898";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "teste2@email.com";
        command.Street = "Street";
        command.Number = "1";
        command.Neighborhood = "Neighborhood";
        command.City = "City";
        command.State = "State";
        command.Country = "Country";
        command.ZipCode = "ZipCode";

        handler.Handle(command);

        Assert.AreEqual(false, handler.IsValid);
    }
}