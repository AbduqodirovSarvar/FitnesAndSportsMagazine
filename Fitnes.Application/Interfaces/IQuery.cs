using MediatR;

namespace Fitnes.Application.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
