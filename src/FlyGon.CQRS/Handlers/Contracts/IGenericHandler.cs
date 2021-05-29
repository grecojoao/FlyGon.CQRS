using System.Threading;
using System.Threading.Tasks;

namespace FlyGon.CQRS.Handlers.Contracts
{
    public interface IGenericHandler<TRequest, TResult>
    {
        Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);
    }
}