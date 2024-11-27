using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    private IList<Payment> _payments;
    public Subscription(DateTime createDate, DateTime? lastUpdateDate, DateTime expireDate, bool active)
    {
        CreateDate = createDate;
        LastUpdateDate = lastUpdateDate;
        ExpireDate = expireDate;
        Active = active;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime? LastUpdateDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public bool Active { get; private set; }
    public IReadOnlyCollection<Payment> Payments { get { return _payments.ToList(); } }

    public void AddPayment(Payment payment) {
        AddNotifications(new Contract<Subscription>()
            .Requires()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data de pagamento deve ser maior que a data atual.")
        );

        if(IsValid)
            _payments.Add(payment);
    }

    public void DisableSubscription() {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }

    public void ActivateSubscription(){
        Active = true;
        LastUpdateDate = DateTime.Now;
    }
}