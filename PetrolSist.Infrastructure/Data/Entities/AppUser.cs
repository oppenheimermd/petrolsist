using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetrolSist.Infrastructure.Data.Entities
{
    //  AppUserRole to avoid clashing with  base types
    public enum AppUserRole { Admin, User, Employee }

    // Add profile data for application users by adding properties to this class
    public class AppUser : IdentityUser<string>
    {
        // Extended Properties
        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Vehicle Manufacture")]
        public string VehicleManufacture { get; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Vehicle Colour")]
        public string VehicleColour { get; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public AppUserRole UserRole { get; set; } = AppUserRole.User;
    }
}
