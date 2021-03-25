using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseManagementApi.Models;

namespace CaseManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseWorkersController : ControllerBase
    {
        private readonly ApiContext _context;

        public CaseWorkersController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/CaseWorkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseWorkers>>> GetCaseWorkers()
        {
            return await _context.CaseWorkers.ToListAsync();
        }

        // GET: api/CaseWorkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseWorkers>> GetCaseWorkers(int id)
        {
            var caseWorkers = await _context.CaseWorkers.FindAsync(id);

            if (caseWorkers == null)
            {
                return NotFound();
            }

            return caseWorkers;
        }

        // PUT: api/CaseWorkers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseWorkers(int id, CaseWorkers caseWorkers)
        {
            if (id != caseWorkers.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseWorkers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseWorkersExists(id))
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

        // POST: api/CaseWorkers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CaseWorkers>> PostCaseWorkers(CaseWorkers caseWorkers)
        {
            _context.CaseWorkers.Add(caseWorkers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CaseWorkersExists(caseWorkers.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaseWorkers", new { id = caseWorkers.Id }, caseWorkers);
        }

        // DELETE: api/CaseWorkers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CaseWorkers>> DeleteCaseWorkers(int id)
        {
            var caseWorkers = await _context.CaseWorkers.FindAsync(id);
            if (caseWorkers == null)
            {
                return NotFound();
            }

            _context.CaseWorkers.Remove(caseWorkers);
            await _context.SaveChangesAsync();

            return caseWorkers;
        }

        private bool CaseWorkersExists(int id)
        {
            return _context.CaseWorkers.Any(e => e.Id == id);
        }
    }
}
