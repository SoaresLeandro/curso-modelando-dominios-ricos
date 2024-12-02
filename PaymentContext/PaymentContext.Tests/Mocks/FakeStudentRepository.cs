using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public void CreateSubscription(Student student)
    {
        throw new NotImplementedException();
    }

    public bool DocumentExists(string document) => document.Equals("999999999");

    public bool EmailExists(string email) => email.Equals("teste@dominio.com");
}