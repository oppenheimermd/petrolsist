
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PetrolSist.Core.Domain.Entities;
using PetrolSist.Core.DTO;
using PetrolSist.Core.DTO.GatewayResponses;
using PetrolSist.Core.Interfaces.Gateways.Repositories;
using PetrolSist.Infrastructure.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PetrolSist.Infrastructure.Data.EntityFramework.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        ///  We start off by mapping our domain user to the data entity <see cref="AppUser"/> and then call the 
        ///  CreateAsync()on _userManager <see cref="UserManager{TUser}"/> to create the user in the database 
        ///  and returning the result, which is of type <see cref="CreateUserResponse"/>.
        public async Task<CreateUserResponse> Create(User user, string password)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            return new CreateUserResponse(
                appUser.Id, identityResult.Succeeded, identityResult.Succeeded ?
                null : identityResult.Errors.Select(e => new Error(e.Code, e.Description))
                );
        }
    }
}
