using FlyGon.CQRS.Commands.Contracts;

namespace FlyGon.CQRS.Commands
{
    /// <summary>
    /// Implements the result of processing a <see cref="Command"/> through a Handler.
    /// </summary>
    /// <remarks>
    /// This class is used as a return type of <see cref="Handlers.Contracts.ICommandHandler{TCommand, TCommandResult}"/>.
    /// </remarks>
    public class CommandResult : ICommandResult
    {
        /// <summary>
        /// Indicates whether command processing was successful.
        /// </summary>
        public bool Sucess { get; set; }

        /// <summary>
        /// Customized message according to command processing.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Custom data returned by the Command Handler. They can be notifications or persisted classes for example.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Initializes a new instance of CommandResult.
        /// </summary>
        public CommandResult() { }

        /// <summary>
        /// Initializes a new instance of CommandResult with success, message, and return data parameters.
        /// </summary>
        /// <param name="sucess">Inform whether the processing of the command was successful or not.</param>
        /// <param name="message">Custom message.</param>
        /// <param name="data">Custom data.</param>
        public CommandResult(bool sucess, string message, object data = null)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }
    }
}