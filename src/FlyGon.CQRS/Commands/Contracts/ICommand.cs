namespace FlyGon.CQRS.Commands.Contracts
{
    /// <summary>
    /// Interface that defines a command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Specification of the validation contract for the interface.
        /// </summary>
        void Validate();
    }
}