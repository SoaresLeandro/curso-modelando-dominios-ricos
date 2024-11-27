using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var document = new Document("00", EDocumentType.CNPJ);
        Assert.IsTrue(!document.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsvalid()
    {
        var document = new Document("87164344000114", EDocumentType.CNPJ);
        Assert.IsTrue(document.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var document = new Document("2541814208", EDocumentType.CPF);
        Assert.IsTrue(!document.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsvalid()
    {
        var document = new Document("25418142089", EDocumentType.CPF);
        Assert.IsTrue(document.IsValid);
    }
}