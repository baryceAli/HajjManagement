using CoreBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Util
{
    public class AuthService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly JwtSettings jwtSettings;

        public AuthService(UserManager<User> userManager, RoleManager<Role> roleManager, IOptions<JwtSettings> jwtSettings)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtSettings = jwtSettings.Value;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var roleName in roles)
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var roleSpecificClaims = await roleManager.GetClaimsAsync(role);
                    roleClaims.AddRange(roleSpecificClaims);
                }
            }

            // Combine user and role claims (avoiding duplicates)
            var allPermissions = userClaims
                .Where(c => c.Type == "Permission")
                .Select(c => c.Value)
                .Concat(roleClaims.Where(c => c.Type == "Permission").Select(c => c.Value))
                .Distinct()
                .ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Add role names
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            // Add permissions as individual claims
            claims.AddRange(allPermissions.Select(p => new Claim("Permission", p)));

            // Combine all claims
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
