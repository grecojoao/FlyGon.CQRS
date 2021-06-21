using FlyGon.CQRS.Commands.Contracts;
using FlyGon.Notifications;

namespace FlyGon.CQRS.Commands
{
    /// <summary>
    /// Base class for implementing notifiable commands.
    /// </summary>
    /// <remarks>
    /// Implements <seealso cref="ICommand"/>, which in addition to being a command also validates its own properties.
    /// Implements <seealso cref="Notifiable"/> which makes the command notifiable.
    /// Use this class as the base class of a command.
    /// <para/>Create a property for each parameter required for processing the command.
    /// </remarks>
    public abstract class Command : Notifiable, ICommand
    {
        /// <summary>
        /// Validate input parameters.
        /// </summary>
        /// <remarks>
        /// Implement validation of input parameters.
        /// In an inherited class, validate all command parameters in this method.
        /// </remarks>
        public abstract void Validate();
    }
}