using BaseLib.Utilities.ApiResponses;
using BaseLib.Utilities.Security;
using Microsoft.AspNetCore.Mvc;

namespace OnlineWS.WebAPI.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class AuthenticationController : ControllerBase
        {
            private readonly IConfiguration _configuration;
            public AuthenticationController(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            // ....api/authentication/gettoken
            [HttpGet("gettoken")]
            public async Task<IActionResult> GetToken()
            {
                var accessToken = new JwtGenerator(_configuration).CreateAccessToken();

                return Ok(ApiResponse<AccessToken>.Success(200, accessToken));
            }
        }
    }
