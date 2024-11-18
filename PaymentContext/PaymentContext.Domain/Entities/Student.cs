namespace PaymentContext.Domain.Entities;

public class Student
{
    private IList<Subscription> _subscriptions;
    public Student(string firstName, string lastName, string document, string email, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
        Address = address;
        _subscriptions = new List<Subscription>();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
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