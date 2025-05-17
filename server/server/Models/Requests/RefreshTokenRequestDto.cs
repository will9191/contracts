using System.ComponentModel.DataAnnotations;

namespace server.Models.Requests
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public required string RefreshToken { get; set; }
    }
}
