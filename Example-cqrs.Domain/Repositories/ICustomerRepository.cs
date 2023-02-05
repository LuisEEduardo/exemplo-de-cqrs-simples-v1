using Example_cqrs.Domain.Entities;

namespace Example_cqrs.Domain.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByName(string name);
        Task<Customer> GetByEmail(string email);
        Task<IEnumerable<Customer>> GetAll();
        Task Create(Customer customer);
        Task Update(Customer customer);
        Task SaveChanges();
    }
}
