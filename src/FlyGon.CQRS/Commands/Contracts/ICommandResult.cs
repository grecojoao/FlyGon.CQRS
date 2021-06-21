namespace FlyGon.CQRS.Commands.Contracts
{
    /// <summary>
    /// Interface that defines the result of processing commands.
    /// </summary>
    /// <remarks>
    /// Implement to create a command result for processing the <seealso cref="Handlers.Contracts.ICommandHandler{TCommand, TCommandResult}.Handle(TCommand, System.Threading.CancellationToken)"/>.
    /// </remarks>
    public interface ICommandResult
    {
        /// <summary>
        /// Indicates whether command processing was successful.
        /// <para/>See more about commands at <seealso cref="ICommand"/>.
        /// </summary>
        bool Sucess { get; set; }

        /// <summary>
        /// Custom message about command processing.
        /// <para/>See more about commands at <seealso cref="ICommand"/>.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Custom data returned by the Command Handler. They can be notifications or persisted classes for example.
        /// </summary>
        object Data { get; set; }
    }
}