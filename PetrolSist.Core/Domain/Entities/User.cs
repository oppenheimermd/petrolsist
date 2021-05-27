
namespace PetrolSist.Core.Domain.Entities
{
    public class User
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string PasswordHash { get; }
        public string VehicleManufacture { get; }
        public string VehicleColour { get; }

        internal User(
            string firstname,
            string lastname,
            string email,
            string username,
            string vehiclemanufacture,
            string vehiclecolour,            
            string passwordhash = null,
            string id = null
            )
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            UserName = username;
            PasswordHash = passwordhash;
            VehicleManufacture = vehiclemanufacture;
            VehicleColour = vehiclecolour;
        }

   }
}
