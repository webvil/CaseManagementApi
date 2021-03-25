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
    public class CaseStatusController : ControllerBase
    {
        private readonly ApiContext _context;

        public CaseStatusController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/CaseStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseStatus>>> GetCaseStatus()
        {
            return await _context.CaseStatus.ToListAsync();
        }

        // GET: api/CaseStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseStatus>> GetCaseStatus(int id)
        {
            var caseStatus = await _context.CaseStatus.FindAsync(id);

            if (caseStatus == null)
            {
                return NotFound();
            }

            return caseStatus;
        }

        // PUT: api/CaseStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseStatus(int id, CaseStatus caseStatus)
        {
            if (id != caseStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseStatusExists(id))
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

        // POST: api/CaseStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CaseStatus>> PostCaseStatus(CaseStatus caseStatus)
        {
            _context.CaseStatus.Add(caseStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CaseStatusExists(caseStatus.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaseStatus", new { id = caseStatus.Id }, caseStatus);
        }

        // DELETE: api/CaseStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CaseStatus>> DeleteCaseStatus(int id)
        {
            var caseStatus = await _context.CaseStatus.FindAsync(id);
            if (caseStatus == null)
            {
                return NotFound();
            }

            _context.CaseStatus.Remove(caseStatus);
            await _context.SaveChangesAsync();

            return caseStatus;
        }

        private bool CaseStatusExists(int id)
        {
            return _context.CaseStatus.Any(e => e.Id == id);
        }
    }
}
