using Example_cqrs.Domain.Command.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Example_cqrs.Domain.Command
{
    public class AlterCustomerStatusCommand : Notifiable, ICommand
    {
        public AlterCustomerStatusCommand()
        {
        }

        public AlterCustomerStatusCommand(Guid id, bool status)
        {
            Id = id;
            Status = status;
        }

        public Guid Id { get; set; }
        public bool Status { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract()
                                    .Requires()
                                    .IsNotNull(Id, "Id", "O Id não pode ser nulo")
                                    .IsNotNull(Status, "Status", "O Status não pode ser nulo"));
        }
    }
}
