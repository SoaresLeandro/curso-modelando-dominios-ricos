using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands;

[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FisrtName = "";
        command.Validate();

        Assert.IsTrue(!command.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenNameIsValid()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FisrtName = "NameValid";
        command.Validate();

        Assert.IsTrue(command.IsValid);
    }
}