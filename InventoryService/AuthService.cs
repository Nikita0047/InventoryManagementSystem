using InventoryModels.Auth;
using InventoryModels.DTOs;
using InventoryService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService
{
    public class AuthService : IAuth
    {

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUserRepo _UserRepo;
        private readonly IConfiguration _config;
        public AuthService(IUnitOfWork unitOfWork, IUserRepo userRepo, IConfiguration config)
        {

            _UnitOfWork = unitOfWork;
            _UserRepo = userRepo;
            _config = config;
        }

        public async Task<AuthResponse> SignInAsync(SignIn request)
        {
            if (request == null ||
                    string.IsNullOrWhiteSpace(request.Email) ||
                     string.IsNullOrWhiteSpace(request.Password))
                throw new ArgumentException("Invalid login request");
            var email = request.Email.Trim().ToLower();
            var user = await _UserRepo.GetByEmailAsync(email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
                throw new UnauthorizedAccessException("Invalid username or password ");



            var expiryMinutes = int.Parse(_config["Jwt:ExpiryMinutes"]);
            var token = await GenrateJwtToken(user);

            return new AuthResponse
            {

                UserId = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(expiryMinutes),


            };

        }

       
        public async Task<AuthResponse> SignUpAsync(SignUp request)
        {
            var Email = request.Email?.Trim().ToLower();
            var Password = request.Password?.Trim();
            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("Email is required");


            if (string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("Password is required");

            if (await _UserRepo.GetByEmailAsync(Email) != null)
                throw new InvalidOperationException("Email already exists");

            if (string.IsNullOrWhiteSpace(request.FirstName))
                throw new ArgumentException("First name is required");

            if (string.IsNullOrWhiteSpace(request.LastName))
                throw new ArgumentException("Last name is required");

            var username = $"{request.FirstName}.{request.LastName}".ToLower();
            if (await _UserRepo.UsernameExistsAsync(username))
                throw new InvalidOperationException("Username is already taken");


            var user = new Users
            {
                Email = Email,
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password),
                CreatedAt = DateTime.UtcNow,

            };

            await _UserRepo.AddAsync(user);
            await _UnitOfWork.SaveAsync();

            var token = await GenrateJwtToken(user);

            return new AuthResponse
            {
                UserId = user.Id,
                Email = user.Email,
                FullName = $"{user.FirstName} {user.LastName}",
                Token = token
            };

        }
        private async Task<string> GenrateJwtToken(Users user)
        {
            var jwtSettings =  _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            //it creates a symmetric security key using
            //the secret key specified in the configuration.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset
                .UtcNow.ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64),

            };
            // List of claims to be included in the JWT token, such as user ID, email, role, and a unique identifier (JTI).
               var permissions =  await _UnitOfWork.Repository<UsersRole>()
    .           GetQuery()
               .Where(ur => ur.UserId == user.Id)
               .SelectMany(ur => ur.Role.RolePermissions)
               .Select(rp => rp.Permission.Code)
               .ToListAsync();


            foreach (var permission in permissions)
            {
                claims.Add(new Claim("permission", permission));
            }

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // It creates signing credentials using the symmetric key and specifies the HMAC SHA256 algorithm for signing the token.
            var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"]);
            var token = new JwtSecurityToken
              (
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: creds
              );
            // It creates a new JWT token with the specified issuer, audience, claims, expiration time, and signing credentials.
            //it is a standard microsoft class for JWT token handling,
            //it provides methods for creating and validating JWT tokens.
            return new JwtSecurityTokenHandler().WriteToken(token);
            // Finally, it returns the generated JWT token as a string using the WriteToken method of the JwtSecurityTokenHandler class.
        }

    }
}
    

