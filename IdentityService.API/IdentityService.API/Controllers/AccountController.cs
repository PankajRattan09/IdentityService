using IdentityService.OktaSecurity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiversion}/account")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AccountController(ITokenService tokenService) => _tokenService = tokenService;

        /// <summary>
        /// Genarate okta security token to authrize api requests
        /// </summary>
        /// <returns>Okta security token</returns>
        [HttpGet]
        [Route("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetToken() =>
            Ok(await _tokenService.GetToken());
    }
}
