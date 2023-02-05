using Example_cqrs.Domain.Command.Contracts;

namespace Example_cqrs.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
