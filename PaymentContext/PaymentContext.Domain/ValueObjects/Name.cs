using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FisrtName = firstName;
        LastName = lastName;        

        if(string.IsNullOrEmpty(FisrtName))
            AddNotification("Name.FirstName", "Nome inválido");

        if(string.IsNullOrEmpty(LastName))
        AddNotification("Name.LastName", "Nome inválido");
    }

    public string FisrtName { get; private set;}
    public string LastName { get; private set; }
}