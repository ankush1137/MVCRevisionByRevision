using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web;
using Web.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/States
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
          if (_context.States == null)
          {
              return NotFound();
          }
            return await _context.States.ToListAsync();
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
          if (_context.States == null)
          {
              return NotFound();
          }
            var state = await _context.States.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest("Given Id and stateId is invalid");
            }

            _context.Update(state);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(state);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
          if (_context.States == null)
          {
              return Problem("Entity set 'AppDbContext.States'  is null.");
          }
            _context.States.Add(state);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetState", new { id = state.Id }, state);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type =typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type =typeof(string))]
        public async Task<IActionResult> DeleteState(int id)
        {
            if (_context.States == null)
            {
                return NotFound("Model is not existed");
            }
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound("Model is not existed");
            }

           var num = _context.States.Remove(state);
            await _context.SaveChangesAsync();
            if (num == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Server Error");
            }

            return Ok(state);
        }

        private bool StateExists(int id)
        {
            return (_context.States?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
