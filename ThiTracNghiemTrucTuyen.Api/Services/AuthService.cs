using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ThiTracNghiemTrucTuyen.Api.Data;
using ThiTracNghiemTrucTuyen.Api.Data.Entities;
using ThiTracNghiemTrucTuyen.Shared.DTOs;

namespace ThiTracNghiemTrucTuyen.Api.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task LoginAsync(LoginDto loginDto )
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync( u => u.Email == loginDto.Username);
            if(user == null)
            {
                return;
            }
          var passwordVerificationResult =  _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if(passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                //Sai mật khẩu
                return;
            }
            var jwt = GenerateJwtToken(user);
        }
        private static string GenerateJwtToken(User user) {
            Claim[] claims = 
                [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Role),
                ];
            var secretKey = ""; // lấy từ appsettings.json
            var symmetricyKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var signingCred = new SigningCredentials(symmetricyKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(issuer: "", audience: "", claims: claims, expires: DateTime.UtcNow.AddMinutes(10),signingCredentials: signingCred);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
