using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private IList<Subscription> _subscriptions;
    public Student(Name name, Document document, Email email, Address address)
    {
        Name = name;
        Document = document;
        Email = email;
        Address = address;
        _subscriptions = new List<Subscription>();

        AddNotifications(name, document, email, address);
    }

    public Name Name { get; set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToList(); } }

    public void AddSubscription(Subscription subscription){
       bool hasSubscriptionActive = false;

       foreach (var sub in _subscriptions)
        if(sub.Active)
            hasSubscriptionActive = true;

        AddNotifications(new Contract<Student>()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já possui uma assinatura ativa.")
            .IsLowerOrEqualsThan(0, subscription.Payments.Count, "Esta assinatura não possui um pagamento")
        );
    }
}