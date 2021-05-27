
using System.Threading.Tasks;
using PetrolSist.Core.Domain.Entities;
using PetrolSist.Core.DTO.GatewayResponses;


namespace PetrolSist.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
    }
}
