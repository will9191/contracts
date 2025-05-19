using System.Text.Json.Serialization;

namespace desktop.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("accessToken")]
        public required string AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public required string RefreshToken { get; set; }
    }
}
