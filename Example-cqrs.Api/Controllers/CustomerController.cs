using Example_cqrs.Domain.Command;
using Example_cqrs.Domain.Entities;
using Example_cqrs.Domain.Handlers;
using Example_cqrs.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example_cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<Customer>> GetAll()
            => await _repository.GetAll();

        [HttpGet("get-by-id")]
        public async Task<Customer> GetByName(Guid id)
            => await _repository.GetById(id);

        [HttpGet("get-by-name")]
        public async Task<Customer> GetByName(string name)
            => await _repository.GetByName(name);

        [HttpGet("get-by-email")]
        public async Task<Customer> GetByEmail(string email)
            => await _repository.GetByEmail(email);

        [HttpPost("create")]
        public async Task<GenericCommandResult> Create(CreateCustomerCommand command, [FromServices] CustomerHandler customerHandler)
            => (GenericCommandResult)await customerHandler.Handle(command);

        [HttpPut("update")]
        public async Task<GenericCommandResult> Update(UpdateCustomerCommand command, [FromServices] CustomerHandler customerHandler)
            => (GenericCommandResult)await customerHandler.Handle(command);

        [HttpPatch("alter-status")]
        public async Task<GenericCommandResult> AlterCustomerStatus(AlterCustomerStatusCommand command, [FromServices] CustomerHandler customerHandler)
            => (GenericCommandResult)await customerHandler.Handle(command);
    }
}
