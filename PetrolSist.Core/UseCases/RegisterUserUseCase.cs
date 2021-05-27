
using PetrolSist.Core.Domain.Entities;
using PetrolSist.Core.DTO.UseCaseRequests;
using PetrolSist.Core.DTO.UseCaseResponses;
using PetrolSist.Core.Interfaces;
using PetrolSist.Core.Interfaces.Gateways.Repositories;
using PetrolSist.Core.Interfaces.UserCases;
using System.Linq;
using System.Threading.Tasks;

namespace PetrolSist.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// The signature contains two parameters: <see cref="RegisterUserRequest"/>`message` 
        /// and `outputPort`. The message parameter is an Input Port whose sole responsibility 
        /// is to carry the request model into the  use case from the upper layer that trigged it
        /// (UI, controller etc.). This class is simply a lightweight DTO owned by the Core/Domain layer.
        /// "outputZone" <see cref="RegisterUserResponse"/>  is responsible for getting data out of 
        /// the use case into a form suitable for its caller. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputZone"></param>
        /// <returns></returns>
        public async Task<bool> Handle(RegisterUserRequest message, IOutputZone<RegisterUserResponse> outputZone)
        {
            var response = await _userRepository.Create(
                new User(
                    message.FirstName, 
                    message.LastName, 
                    message.Email, 
                    message.UserName,
                    message.VehicleManufacture,
                    message.VehicleColour), 
                message.Password
                );
            outputZone.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
