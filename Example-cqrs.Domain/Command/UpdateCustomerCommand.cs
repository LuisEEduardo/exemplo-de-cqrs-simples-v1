using Example_cqrs.Domain.Command.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Example_cqrs.Domain.Command
{
    public class UpdateCustomerCommand : Notifiable, ICommand
    {
        public UpdateCustomerCommand()
        {
        }

        public UpdateCustomerCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLengthIfNotNullOrEmpty(Name, 60, "Name", "O name tem mais de 60 caracteres")
                    .IsEmail(Email, "Email", "Email inválido")
                    .HasMaxLengthIfNotNullOrEmpty(Email, 100, "Email", "O email tem mais de 100 caracteres")
                    .IsNotNull(BirthDate, "BirthDate", "A birthData não pode ser nula")
                    .IsNotNull(Id, "Id", "O Id não pode ser nulo")
                );
        }
    }
}
