using FlyGon.CQRS.Commands.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace FlyGon.CQRS.Handlers.Contracts
{
    public interface ICommandHandler<TCommand, TCommandResult>
        where TCommand : ICommand
        where TCommandResult : ICommandResult
    {
        Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}