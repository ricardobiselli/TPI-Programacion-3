using Application.Models.Requests;
using Domain.Models.Users;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;


using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AuthenticationController(IConfiguration config, ICustomAuthenticationService customAuthenticationService)
        {
            _config = config;
            _customAuthenticationService = customAuthenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> AuthenticateAsync(UserLoginRequest authenticationRequest)
        {
            string token = await _customAuthenticationService.AuthenticateAsync(authenticationRequest);
            return Ok(token);
        }
    }
}