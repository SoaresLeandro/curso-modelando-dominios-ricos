using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FisrtName = firstName;
        LastName = lastName;        

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsGreaterThan(FisrtName, 3, "Name.FirstName", "O Nome deve ter pelo menos 3 caracteres.")
            .IsGreaterThan(LastName, 3, "Name.LastName", "O Sobrenome deve ter pelo menos 3 caracteres.")
        );
    }

    public string FisrtName { get; private set;}
    public string LastName { get; private set; }
}