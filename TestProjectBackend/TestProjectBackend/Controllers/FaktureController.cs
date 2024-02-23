using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProjectBackend.Services;
using TestProjectBackend.Models.Entities;

namespace TestProjectBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FaktureController : ControllerBase
    {
        private readonly IFakturaService _service;
        public FaktureController(IFakturaService service)
        {
            _service = service;
        }

        [HttpGet("all-fakture")]
        public async Task<ActionResult<List<Faktura>>> GetAllFakture()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("faktura/{id}")]
        public async Task<ActionResult<Faktura>> GetFaktura(Guid id)
        {
            try
            {
                var faktura = await _service.GetFaktura(id);
                return Ok(faktura);
            }catch(Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost("nova-faktura")]
        public async Task<ActionResult<Faktura>> DodajFakturu(Faktura faktura)
        {
            await _service.AddFaktura(faktura);

            return Ok(faktura);
        }

        [HttpPut("izmjena/{id}")]
        public async Task<ActionResult<Faktura>> PutFaktura(Guid id, Faktura faktura)
        {
            if (id != faktura.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateFaktura(id, faktura);
                return Ok();
            } catch(Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-faktura/{id}")]
        public async Task<IActionResult> DeleteFaktura(Guid id)
        {
            try
            {
               await _service.DeleteFaktura(id);
                return Ok();
            } catch(Exception e)
            {
                return NotFound();
            }
        }
    }
}
