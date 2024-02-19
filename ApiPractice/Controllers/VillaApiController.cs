using ApiPractice.Data;
using ApiPractice.Models;
using ApiPractice.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controllers
{
    //[Route("api/[controller]")
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VillaApiController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(_context.Villas.ToList());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]

        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa=_context.Villas.FirstOrDefault(u=>u.Id==id);
            if(villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto) 
        {
            if(villaDto==null)
                return BadRequest();
            if(villaDto.Id>0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            VillaModel model = new()
            {
                Id = villaDto.Id,

                Name = villaDto.Name
            };
            _context.Villas.Add(model);
            _context.SaveChanges();
            return Ok(villaDto);
        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa=_context.Villas.FirstOrDefault(u=>u.Id==id);
            if(villa==null)
            {
                return NotFound();
            }
            _context.Villas.Remove(villa);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if(villaDto== null || id != villaDto.Id)
            {
                return BadRequest();
            }
            VillaModel model = new()
            {
                Id = villaDto.Id,

                Name = villaDto.Name
            };
            _context.Villas.Update(model);
            _context.SaveChanges();
            return Ok();
        }
    }
}
