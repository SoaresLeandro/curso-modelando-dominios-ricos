using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
    {
        _studentRepository = studentRepository;
        _emailService = emailService;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if(command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar o seu cadastro.");        
        }

        //Verificar se o documento existe
        if(_studentRepository.DocumentExists(command.Document))
            AddNotification("Document", "Este CPF já está e uso");

        //Verificar se o e-mail existe
        if(_studentRepository.EmailExists(command.Email))
            AddNotification("Email", "Este e-mail já está em uso");

        //Gerar os VOs
        var name = new Name(command.FisrtName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

        //Gerar as Entidades
        var student = new Student(name, document, email, address);
        var subscription = new Subscription(DateTime.Now.AddMonths(1), null, DateTime.Now.AddMonths(1), true);
        var payment = new BoletoPayment
        (
            command.BarCode, 
            command.BoletoNumber, 
            command.PaidDate, 
            command.ExpireDate, 
            command.Total, 
            command.TotalPaid, 
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType), 
            address, 
            email
        );

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
         
        //Agrupar as validações
        AddNotifications(document, email, address, student, subscription, payment);

        //Salvar as informações
        _studentRepository.CreateSubscription(student);

        //Enviar e-mail de boas vindas
        _emailService.Send(student.Name.ToString(), student.Email.Address, "Assinatura", "Sua assinatura foi realizada.");

        //Retornar informações
        return new CommandResult(true, "Assinatura realizada com sucesso!");
    }
}