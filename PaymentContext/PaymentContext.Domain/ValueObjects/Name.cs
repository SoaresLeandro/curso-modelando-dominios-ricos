using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FisrtName = firstName;
        LastName = lastName;
    }

    public string FisrtName { get; private set;}
    public string LastName { get; private set; }
}