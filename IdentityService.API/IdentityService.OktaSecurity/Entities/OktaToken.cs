using Newtonsoft.Json;

namespace IdentityService.OktaSecurity.Entities
{
    public class OktaToken
    {
        [JsonProperty(propertyName:"access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty(propertyName: "expires_in")]
        public int ExpiresIn { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string? Scope { get; set; }

        [JsonProperty(propertyName: "token_type")]
        public string? TokenType { get; set; }

        public bool IsValidAndNotExpiring
        {
            get
            {
                return !string.IsNullOrWhiteSpace(AccessToken)
                  && this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
            }
        }
    }
}
