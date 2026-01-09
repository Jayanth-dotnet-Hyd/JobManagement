using JobManagement.Applicant.Data.Context;
using JobManagement.Applicant.Data.Models;
using JobManagemnet.Auth.Interfaces;
using JobManagemnet.Auth.models;
using Microsoft.EntityFrameworkCore;


namespace JobManagemnet.Auth
{
    public class AuthService : IAuthService
    {

        private readonly JobManagementDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(JobManagementDbContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }




        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.users
              .Include(u => u.role)
              .FirstOrDefaultAsync(u => u.email == request.Email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(request.Password, user.password_hash)) 
                throw new UnauthorizedAccessException("Invalid email or password");

            var token = _tokenService.GenerateToken(
                user.id,
                user.email,
                user.role.role_name
            );

            return new AuthResponse
            {
                UserId = user.id,
                Email = user.email,
                Role = user.role.role_name,
                Token = token
            };
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var exists = await _context.users
            .AnyAsync(u => u.email == request.Email);

            if (exists)
                throw new Exception("Email already registered");

            var role = await _context.roles
                .FirstOrDefaultAsync(r => r.id == request.RoleId);

            if (role == null)
                throw new Exception("Invalid role");

            var user = new user
            {
                full_name = request.FullName,
                email = request.Email,
                phone = request.Phone,
                role_id = role.id,
                password_hash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow
            };

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            //var token = _tokenService.GenerateToken(
            //    user.id,
            //    user.email,
            //    role.role_name
            //);

            return new RegisterResponse
            {
                UserId = user.id,
                Email = user.email,
                Role = role.role_name
              
            };
        }
    }
}
