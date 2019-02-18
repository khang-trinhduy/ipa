using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermissionApi.Models;

namespace PermissionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GrantsController : ControllerBase
    {
        private readonly PermissionApiContext _context;

        public GrantsController(PermissionApiContext context)
        {
            _context = context;
        }

        // GET: api/Grants
        [HttpGet]
        public IEnumerable<Grant> GetGrant()
        {
            return _context.Grants;
        }

        // GET: api/Grants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grant = await _context.Grants.FindAsync(id);

            if (grant == null)
            {
                return NotFound();
            }

            return Ok(grant);
        }

        [HttpGet("{sub}")]
        public async Task<IActionResult> GetGrant([FromBody]string sub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var grants = await _context.Grants.Where(g => g.UserId == sub).ToListAsync();

            if (grants == null)
            {
                return NotFound();
            }

            return Ok(grants);
        }

        // PUT: api/Grants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrant([FromRoute] int id, [FromBody] Grant grant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grant.Id)
            {
                return BadRequest();
            }

            _context.Entry(grant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrantExists(id))
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

        // POST: api/Grants
        [HttpPost]
        public async Task<IActionResult> PostGrant([FromBody] Grant grant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grants.Add(grant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrant", new { id = grant.Id }, grant);
        }

        // DELETE: api/Grants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grant = await _context.Grants.FindAsync(id);
            if (grant == null)
            {
                return NotFound();
            }

            _context.Grants.Remove(grant);
            await _context.SaveChangesAsync();

            return Ok(grant);
        }

        private bool GrantExists(int id)
        {
            return _context.Grants.Any(e => e.Id == id);
        }
    }
}