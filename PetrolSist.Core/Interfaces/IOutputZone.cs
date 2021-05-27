
namespace PetrolSist.Core.Interfaces
{
    /// <summary>
    /// IOutputZone contract exposes the single method <see cref="Handle(TUseCaseResponse)"/> which
    /// accepts a generic use case response model that gets transformed into the final format required 
    /// by the outer layer.
    /// </summary>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IOutputZone<in TUseCaseResponse>
    {
        /// <summary>
        /// Accepts a generic use case response model that gets transformed into the final format required 
        /// by the outer layer.
        /// </summary>
        /// <param name="response"></param>
        void Handle(TUseCaseResponse response);
    }
}
