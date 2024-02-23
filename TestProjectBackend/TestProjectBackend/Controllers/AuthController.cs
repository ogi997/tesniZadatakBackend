using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TestProjectBackend.Data;
using TestProjectBackend.Models.DTO;
using TestProjectBackend.Models.Entities;
using TestProjectBackend.Models.Requests;
using TestProjectBackend.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace TestProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }


        [HttpPost("register")]
        public async Task<ActionResult<Korisnik>> Register(RegisterRequest registerRequest)
        {
            Console.WriteLine(registerRequest.LastName);
            Console.WriteLine(registerRequest.Phone);
            try
            {
                var userDTO = await _service.Register(registerRequest);
                return CreatedAtAction(nameof(GetUser), new { id = userDTO.Id }, userDTO);
            }
            catch (DbUpdateException ex)
            {
                return Conflict("User with given e-mail already exists!");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            var token = await _service.Login(loginRequest);
            if (token == "User with given e-mail does not exist!")
            {
                return NotFound(token);
            }

            if (token == "Wrong password!")
            {
                return BadRequest(token);
            }
            return Ok(token);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KorisnikDTO>> GetUser(Guid id)
        {
            return (await _service.GetUser(id)) is var user ? Ok(user) : NotFound();
        }

    }
}