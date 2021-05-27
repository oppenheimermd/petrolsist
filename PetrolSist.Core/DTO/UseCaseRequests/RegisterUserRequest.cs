
using PetrolSist.Core.DTO.UseCaseResponses;
using PetrolSist.Core.Interfaces;

namespace PetrolSist.Core.DTO.UseCaseRequests
{
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }
        public string VehicleManufacture { get; }
        public string VehicleColour { get; }

        public RegisterUserRequest(
            string firstname,
            string lastname,
            string email,
            string username,
            string vehiclemanufacture,
            string vehiclecolour,
            string password
            )
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            UserName = username;
            VehicleManufacture = vehiclemanufacture;
            VehicleColour = vehiclecolour;
            Password = password;
        }
    }
}
