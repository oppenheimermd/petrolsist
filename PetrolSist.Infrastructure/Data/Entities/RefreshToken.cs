
using System;
using System.ComponentModel.DataAnnotations;

namespace PetrolSist.Infrastructure.Data.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime Expires { get; set; }
        public virtual AppUser AppUser { get; set; }
        [Required]
        public Guid AppUserId { get; set; }
        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; set; }
    }
}
