using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using TestProjectBackend.Data;
using TestProjectBackend.Models.DTO;
using TestProjectBackend.Models.Entities;
using TestProjectBackend.Models.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TestProjectBackend.Services
{
    public interface IAuthService
    {
        Task<KorisnikDTO> Register(RegisterRequest registerRequest);
        Task<string> Login(LoginRequest loginRequest);
        Task<KorisnikDTO> GetUser(Guid id);
    }
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private IConfiguration _config;

        public AuthService(AppDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var user = _dbContext.Korisnici.FirstOrDefault(x => x.Email == loginRequest.Email);
            if (user == null)
            {
                return "User with given e-mail does not exist!";
            }
            Console.WriteLine(BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password));
            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                return "Wrong password!";
            }
            return GenerateToken(user);
        }

        public async Task<KorisnikDTO> Register(RegisterRequest registerRequest)
        {

            var user = _mapper.Map<Korisnik>(registerRequest);
            user.Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
            await _dbContext.Korisnici.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<KorisnikDTO>(user);
        }

        public async Task<KorisnikDTO> GetUser(Guid id)
        {
            return (await _dbContext.Korisnici.FindAsync(id)) is var user ?
                 _mapper.Map<KorisnikDTO>(user) :
                 null;
        }

        private string GenerateToken(Korisnik user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var issuer = _config["Jwt:Issuer"];
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"]));

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}