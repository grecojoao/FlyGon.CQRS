using FlyGon.CQRS.Commands.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace FlyGon.CQRS.Handlers.Contracts
{
    /// <summary>
    /// Interface for implementing command handlers.
    /// </summary>
    /// <remarks>
    /// Receive requests, process commands and return a command result.
    /// Implement to handle a <see cref="ICommand"/>, perform all the processing and then return a <see cref="ICommandResult"/>.
    /// <para/> Inside the Handler you must inject all the necessary dependencies for the processing of the command, such as data repositories or calls to other services.
    /// </remarks>
    /// <typeparam name="TCommand">Type that inherits from ICommand.</typeparam>
    /// <typeparam name="TCommandResult">Type that inherits from ICommandResult.</typeparam>
    public interface ICommandHandler<TCommand, TCommandResult>
        where TCommand : ICommand
        where TCommandResult : ICommandResult
    {
        /// <summary>
        /// Process a <see cref="ICommand"/> and return a <see cref="ICommandResult"/>.
        /// </summary>
        /// <param name="command">Command to be processed by the handler.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>
        /// Command result containing relevant return data, indicating the state of the post-processing command.
        /// </returns>
        Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}