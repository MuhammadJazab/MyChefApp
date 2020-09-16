using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyChefApi.Data;
using MyChefApi.Models;

namespace MyChefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly MyChefApiContext _context;

        public IdentityController(MyChefApiContext context)
        {
            _context = context;
        }

        // GET: api/Identity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityModel>>> GetIdentityModel()
        {
            return await _context.IdentityModel.ToListAsync();
        }

        // GET: api/Identity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityModel>> GetIdentityModel(string id)
        {
            var identityModel = await _context.IdentityModel.FindAsync(id);

            if (identityModel == null)
            {
                return NotFound();
            }

            return identityModel;
        }

        // PUT: api/Identity/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentityModel(string id, IdentityModel identityModel)
        {
            if (id != identityModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(identityModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Identity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IdentityModel>> PostIdentityModel(IdentityModel identityModel)
        {
            _context.IdentityModel.Add(identityModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdentityModelExists(identityModel.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIdentityModel", new { id = identityModel.UserId }, identityModel);
        }

        // DELETE: api/Identity/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdentityModel>> DeleteIdentityModel(string id)
        {
            var identityModel = await _context.IdentityModel.FindAsync(id);
            if (identityModel == null)
            {
                return NotFound();
            }

            _context.IdentityModel.Remove(identityModel);
            await _context.SaveChangesAsync();

            return identityModel;
        }

        private bool IdentityModelExists(string id)
        {
            return _context.IdentityModel.Any(e => e.UserId == id);
        }
    }
}
