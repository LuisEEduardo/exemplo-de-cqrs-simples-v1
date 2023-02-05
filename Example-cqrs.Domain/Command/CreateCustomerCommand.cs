using Example_cqrs.Domain.Command.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Example_cqrs.Domain.Command
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public CreateCustomerCommand()
        {
        }

        public CreateCustomerCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Status = true;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLengthIfNotNullOrEmpty(Name, 60, "Name", "O name tem mais de 60 caracteres")
                    .IsEmail(Email, "Email", "Email inválido")
                    .HasMaxLengthIfNotNullOrEmpty(Email, 100, "Email", "O email tem mais de 100 caracteres")
                    .IsNotNull(BirthDate, "BirthDate", "A birthData não pode ser nula")
                );
        }
    }
}
