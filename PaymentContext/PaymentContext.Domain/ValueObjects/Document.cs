using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{    
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;

        AddNotifications(new Contract<Document>()
            .Requires().
            IsTrue(Validate(), "Document.Number", "Documento inválido.")
        );
    }

    public EDocumentType Type { get; private set; }
    public string Number { get; private set; }

    private bool Validate(){
        if(Type.Equals(EDocumentType.CNPJ) && !Number.Length.Equals(14))
            return false;

        if(Type.Equals(EDocumentType.CPF) && !Number.Length.Equals(11))
            return false;

        return true;
    }
}