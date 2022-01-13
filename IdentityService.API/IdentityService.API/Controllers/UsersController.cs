using IdentityService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace IdentityService.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiversion}/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) => _userService = userService;

        /// <summary>
        /// Read user details from db using aplid
        /// </summary>
        /// <param name="id">id represents aplid</param>
        /// <returns>UserDetailsViewModels</returns>
        /// <exception cref="Exception">Required parameter - AplId</exception>
        [HttpGet]
        [Route("userid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByUserId([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Missing required parameter - aplid");

            var userDetails = await _userService.GetUserById(id, FromAplId: true);

            if (userDetails == null)
                return NotFound();

            return Ok(userDetails);
        }


        /// <summary>
        /// Read user details from db using userguid
        /// </summary>
        /// <param name="id">id represents userguid</param>
        /// <returns>UserDetailsViewModels as base64 string</returns>
        /// <exception cref="Exception">Required parameter - UserGuid</exception>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Missing required parameter - userguid");

            var userDetails = await _userService.GetUserById(id);

            if (userDetails == null)
                return NotFound();

            string json = JsonConvert.SerializeObject(userDetails);

            string base64EncodeduserDetails = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            return Ok(base64EncodeduserDetails);
        }
    }
}
