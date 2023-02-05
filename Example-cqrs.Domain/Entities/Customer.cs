namespace Example_cqrs.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
        }

        public Customer(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Status = true;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Status { get; set; }

        public void Edit(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public void AlterStatus(bool status)
        {
            Status = status;
        }

    }
}
