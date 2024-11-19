using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests{

    [TestMethod]
    public void AdicionarAssinatura(){
        var name = new Name("Name", "LastName");
        var document = new Document("000.000.00-00", EDocumentType.CPF);
        var email = new Email("teste@email.com");
        var address = new Address("", "", "", "", "", "", "");
        
        Student student = new Student(name, document, email, address);
        Subscription subscription = new Subscription(DateTime.Now, null, DateTime.Now.AddMonths(1), true);

        student.AddSubscription(subscription);
    }
}