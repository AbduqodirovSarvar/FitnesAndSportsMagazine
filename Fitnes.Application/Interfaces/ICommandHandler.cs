using MediatR;

namespace Fitnes.Application.Interfaces
{
    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
    }
}
