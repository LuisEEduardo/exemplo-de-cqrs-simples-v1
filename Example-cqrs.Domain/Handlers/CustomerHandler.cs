using Example_cqrs.Domain.Command;
using Example_cqrs.Domain.Command.Contracts;
using Example_cqrs.Domain.Entities;
using Example_cqrs.Domain.Handlers.Contracts;
using Example_cqrs.Domain.Repositories;
using Flunt.Notifications;

namespace Example_cqrs.Domain.Handlers
{
    public class CustomerHandler :
        Notifiable,
        IHandler<CreateCustomerCommand>,
        IHandler<UpdateCustomerCommand>,
        IHandler<AlterCustomerStatusCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ICommandResult> Handle(CreateCustomerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, a algo de errado com o customer", command.Notifications);

            var customer = new Customer(command.Name, command.Email, command.BirthDate);

            await _customerRepository.Create(customer);

            return new GenericCommandResult(true, "Customer criado", customer);
        }

        public async Task<ICommandResult> Handle(UpdateCustomerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, a algo de errado com o customer", command.Notifications);

            var customer = await _customerRepository.GetById(command.Id);

            if (customer is null)
                return new GenericCommandResult(false, "Ops, a algo de errado com o customer", "Customer não encotrado");

            customer.Edit(command.Name, command.Email, command.BirthDate);

            await _customerRepository.Update(customer);

            return new GenericCommandResult(true, "Customer atualizado", customer);
        }

        public async Task<ICommandResult> Handle(AlterCustomerStatusCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, a algo de errado com o customer", command.Notifications);

            var customer = await _customerRepository.GetById(command.Id);

            if (customer is null)
                return new GenericCommandResult(false, "Ops, a algo de errado com o customer", "Customer não encotrado");

            customer.AlterStatus(command.Status);

            await _customerRepository.Update(customer);

            return new GenericCommandResult(true, "Customer atualizado", customer);
        }
    }
}
