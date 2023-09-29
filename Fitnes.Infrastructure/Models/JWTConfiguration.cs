namespace Fitnes.Infrastructure.Models
{
    public class JWTConfiguration
    {
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
    }
}
