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
        var activeSubscriptions = _subscriptions.Where(s => s.Active.Equals(true)).ToList();

        if(activeSubscriptions.Count > 0){
            foreach(var activeSubscription in activeSubscriptions)
                activeSubscription.DisableSubscription();
        }

        _subscriptions.Add(subscription);
    }
}