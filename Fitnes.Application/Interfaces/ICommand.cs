using MediatR;

namespace Fitnes.Application.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
