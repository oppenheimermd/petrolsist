using System.Threading.Tasks;

namespace PetrolSist.Core.Interfaces
{
    /// <summary>
    /// Defines the shape of all of our use case classes.
    /// </summary>
    /// <typeparam name="TUseCaseRequest"></typeparam>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputZone<TUseCaseResponse> outputPort);
    }
}
