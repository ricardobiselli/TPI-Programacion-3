using Application.Interfaces;
using Domain.IRepositories;
using Application.Models.Requests;
using Domain.Models.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class CustomAuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationServiceOptions _options;

        public CustomAuthenticationService(IUserRepository userRepository, IOptions<AuthenticationServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        public async Task<string> AuthenticateAsync(UserLoginRequest authenticationRequest)
        {
            var user = await _userRepository.GetUserByEmailOrUsername(authenticationRequest.UserNameOrEmail);
            if (user == null || user.Password != authenticationRequest.Password)
            {
                throw new UnauthorizedAccessException("User authentication failed");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("userName", user.UserName),
                new Claim(ClaimTypes.Role, user.UserType)
            };

            if (user is Client client)
            {
                claimsForToken.Add(new Claim("firstName", client.FirstName));
                claimsForToken.Add(new Claim("lastName", client.LastName));
            }

            Console.WriteLine($"Creating token with claims: {string.Join(", ", claimsForToken.Select(c => $"{c.Type}: {c.Value}"))}");

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
        public class AuthenticationServiceOptions
        {
            public const string AuthenticationService = "AuthenticationService";
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }

    }

}