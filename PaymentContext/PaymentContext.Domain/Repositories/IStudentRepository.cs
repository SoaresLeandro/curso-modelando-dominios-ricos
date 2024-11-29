using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories;

public interface IStudentRepository{
    bool DocumentExists(string document);
    bool EmailExist(string email);

    void CreateSubscription(Student student);
}