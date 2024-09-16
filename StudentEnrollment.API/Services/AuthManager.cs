using StudentEnrollment.API.DTOs.Authentication;
using Microsoft.AspNetCore.Identity;
using StudentEnrollment.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
namespace StudentEnrollment.API.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<SchoolUser> _userManager;
        private readonly IConfiguration _configuration;
        private SchoolUser? _schoolUser;

        public AuthManager(UserManager<SchoolUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            _schoolUser = await _userManager.FindByEmailAsync(loginDto.EmailAddress);
            if(_schoolUser is null)
            {
                return default;
            }
            bool isValidCredential= await _userManager.CheckPasswordAsync(_schoolUser, loginDto.Password);
            if (!isValidCredential)
            {
                return default;
            }
            var token = await GenerateTokenAsync();
            return new AuthResponseDto
            {
                UserId = _schoolUser.Id,
                Token = token
            };
            // Implementation here
        }

        public async  Task<IEnumerable<IdentityError>> Register(RegisterDto registerDto)
        {
            // Implementation here
            _schoolUser = new SchoolUser
            {
                DateOfBirth = registerDto.DateOfBirth,
                Email = registerDto.EmailAddress,
                UserName = registerDto.EmailAddress,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName

            };
            var result =await _userManager.CreateAsync(_schoolUser, registerDto.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_schoolUser, "User");
            }
            return result.Errors;
        }

        private async Task<string> GenerateTokenAsync()
        {
            var userClaims = await _userManager.GetClaimsAsync(_schoolUser);
            var roles = await _userManager.GetRolesAsync(_schoolUser);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new List<Claim>
            {  
                new Claim("userId", _schoolUser.Id), 


                new Claim(JwtRegisteredClaimNames.Sub, _schoolUser.UserName),
                new Claim(ClaimTypes.Name, _schoolUser.UserName),
                new Claim("fullName", _schoolUser.FirstName + " " + _schoolUser.LastName),
                new Claim(ClaimTypes.Email, _schoolUser.Email),
                //new Claim(CustomClaimTypes.Uid, _schoolUser.Id),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                //new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"])
            }.Union(userClaims).Union(roleClaims);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInHours"]));
            var jwtSecurityToken = new JwtSecurityToken
            (
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );
            // return jwtSecurityToken;
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

    }
}
