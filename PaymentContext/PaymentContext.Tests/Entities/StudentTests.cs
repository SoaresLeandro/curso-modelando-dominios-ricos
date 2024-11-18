using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests{

    [TestMethod]
    public void AdicionarAssinatura(){
        Student student = new Student("Leandro", "Soares", "001.001.001-00", "teste@email.com", "Address");
        Subscription subscription = new Subscription(DateTime.Now, null, DateTime.Now.AddMonths(1), true);

        student.AddSubscription(subscription);
    }
}