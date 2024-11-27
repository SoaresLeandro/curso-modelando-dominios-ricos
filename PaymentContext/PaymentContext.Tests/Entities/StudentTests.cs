using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Document _document;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("FirstName", "LastName");
        _document = new Document("02611337055", EDocumentType.CPF);
        _email = new Email("teste@email.com");
        _address = new Address("", "", "", "", "", "", "");
        _student = new Student(_name, _document, _email, _address);
        _subscription = new Subscription(DateTime.Now, null, DateTime.Now.AddMonths(1), true);
    }

    // [TestMethod]
    // public void ShouldReturnErrorWhenHadActiveSubscription()
    // {
    //     var payment = new PayPaylPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Teste", _document, _address, _email);

    //     _subscription.AddPayment(payment);
    //     _student.AddSubscription(_subscription);
    //     _student.AddSubscription(_subscription);

    //     Assert.IsTrue(!_student.IsValid);
    // }

    // [TestMethod]
    // public void ShouldReturnErrorWhenHadSubscriptionHadNoPayment()
    // {
    //     _student.AddSubscription(_subscription);

    //     Assert.IsTrue(!_student.IsValid);
    // }

    [TestMethod]
    public void ShouldReturnSuccessWhenHadNoActiveSubscription()
    {
        var payment = new PayPaylPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Teste", _document, _address, _email);

        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}