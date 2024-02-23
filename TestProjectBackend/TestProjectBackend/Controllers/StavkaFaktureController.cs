using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProjectBackend.Models.Entities;
using TestProjectBackend.Services;

namespace TestProjectBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StavkaFaktureController : ControllerBase
    {
        private readonly IStavkaFaktureService _service;

        public StavkaFaktureController(IStavkaFaktureService service)
        {
            _service = service;
        }

        [HttpGet("all-stavkaFakture")]
        public async Task<ActionResult<List<StavkaFakture>>> GetAllStavkaFakture()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("stavkaFaktura/{id}")]
        public async Task<ActionResult<StavkaFakture>> GetFaktura(Guid id)
        {
            try
            {
                var stavkaFaktura = await _service.GetStavkaFakture(id);
                return Ok(stavkaFaktura);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost("nova-stavkaFaktura/{idFakture}")]
        public async Task<ActionResult<StavkaFakture>> DodajFakturu(Guid idFakture, StavkaFakture stavkaFakture)
        {
            await _service.AddStavkaFakture(idFakture,stavkaFakture);

            return Ok(stavkaFakture);
        }

        [HttpPut("izmjena/{idFakture}/{idStavke}")]
        public async Task<ActionResult<StavkaFakture>> PutFaktura(Guid idFakture, Guid idStavke, StavkaFakture stavkaFakture)
        {
 

            try
            {
                await _service.UpdateStavkaFakture(idFakture, idStavke, stavkaFakture);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-stavkaFaktura/{idFakture}/{idStavke}")]
        public async Task<IActionResult> DeleteFaktura(Guid idFakture, Guid idStavke)
        {
            try
            {
                await _service.DeleteStavkaFakture(idFakture, idStavke);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
