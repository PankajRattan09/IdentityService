using IdentityService.OktaSecurity.Entities;
using IdentityService.OktaSecurity.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace IdentityService.OktaSecurity.Services
{
    public class TokenService : ITokenService
    {
        private OktaToken _oktaToken;
        private readonly IOptions<OktaSettings> _oktaSettings;
        public TokenService(IOptions<OktaSettings> oktaSettings)
        {
            _oktaToken = new OktaToken();
            _oktaSettings = oktaSettings;
        }

        public async Task<string> GetToken()
        {
            if (!_oktaToken.IsValidAndNotExpiring)
                _oktaToken = await GetNewAccessToken();

            return _oktaToken.AccessToken;
        }

        private async Task<OktaToken> GetNewAccessToken()
        {
            var token = new OktaToken();
            var client = new HttpClient();
            var client_id = _oktaSettings.Value.ClientId;
            var client_secret = _oktaSettings.Value.ClientSecret;
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));

            var postMessage = new Dictionary<string, string>();
            postMessage.Add("grant_type", "client_credentials");
            postMessage.Add("scope", "access_token");
            var request = new HttpRequestMessage(HttpMethod.Post, _oktaSettings.Value.TokenUrl)
            {
                Content = new FormUrlEncodedContent(postMessage)
            };

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<OktaToken>(json);
                token.ExpiresAt = DateTime.UtcNow.AddSeconds(this._oktaToken.ExpiresIn);
            }
            else
            {
                throw new ApplicationException("Unable to retrieve access token from Okta");
            }

            return token;
        }
    }
}
