using System.Threading;
using System.Threading.Tasks;

namespace FlyGon.CQRS.Handlers.Contracts
{
    /// <summary>
    /// Standard interface for implementing custom generic handlers.
    /// </summary>
    /// <remarks>
    /// Receive requests, process data and return a result.
    /// Implement to handle custom parameters, perform all processing and then return custom data.
    /// <para/> Inside the Handler you must inject all the necessary dependencies for the processing of your inputs, such as data repositories or calls to other services.
    /// </remarks>
    /// <typeparam name="TRequest">Type that inherits from ICommand.</typeparam>
    /// <typeparam name="TResult">Type that inherits from ICommandResult.</typeparam>
    public interface IGenericHandler<TRequest, TResult>
    {
        /// <summary>
        /// Process a custom request and return custom data.
        /// </summary>
        /// <param name="request">Input to be processed by handler.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>
        /// Result containing relevant return data, you can indicate, for example, the status of the post-processing request.
        /// </returns>
        Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);
    }
}