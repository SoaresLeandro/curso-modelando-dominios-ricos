namespace PaymentContext.Domain.Entities;

public class Subscription
{
    private IList<Payment> _payments;
    public Subscription(DateTime createDate, DateTime? lastUpdateDate, DateTime expireDate, bool active)
    {
        CreateDate = createDate;
        LastUpdateDate = lastUpdateDate;
        ExpireDate = expireDate;
        Active = active;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime? LastUpdateDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public bool Active { get; private set; }
    public IReadOnlyCollection<Payment> Payments { get { return _payments.ToList(); } }

    public void AddPayment(Payment payment) => _payments.Add(payment);

    public void DisableSubscription() {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }

    public void ActivateSubscription(){
        Active = true;
        LastUpdateDate = DateTime.Now;
    }
}