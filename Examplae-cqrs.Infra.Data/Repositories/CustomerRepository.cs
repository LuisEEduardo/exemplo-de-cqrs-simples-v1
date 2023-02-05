using Examplae_cqrs.Infra.Data.Context;
using Example_cqrs.Domain.Entities;
using Example_cqrs.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Examplae_cqrs.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<Customer>();
        }

        public async Task Create(Customer customer)
        {
            _dbSet.Add(customer);
            await SaveChanges();
        }

        public async Task<IEnumerable<Customer>> GetAll()
            => await _dbSet.ToListAsync();

        public async Task<Customer> GetByEmail(string email)
            => await _dbSet.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

        public async Task<Customer> GetById(Guid id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Customer> GetByName(string name)
            => await _dbSet.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

        public async Task Update(Customer customer)
        {
            _dbSet.Update(customer);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
