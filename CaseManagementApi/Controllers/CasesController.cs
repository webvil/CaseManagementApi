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
    public class CasesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CasesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cases>>> GetCases()
        {
            return await _context.Cases
                .Include(c => c.CaseStatus)
                .Include(c => c.CaseWorker)
                .Include(c => c.Customer)
                /*.FromSqlRaw(
                    "SELECT dbo.Cases.Id, " +
                    "CaseStatusId, " +
                    "CaseWorkerId, " +
                    "CustomerId, " +
                    "Modified, " +
                    "dbo.CaseWorkers.FirstName, " +
                    "dbo.CaseWorkers.LastName, " +
                    "dbo.Customers.FirstName AS CustomerFirstName, " +
                    "dbo.Customers.LastName AS CustomerLastName, " +
                    "Title, " +
                    "Description, " +
                    "Created,  " +
                    "Status " +
                    "FROM dbo.Cases " +
                    "INNER JOIN dbo.CaseWorkers " +
                    "ON dbo.Cases.CaseWorkerId = dbo.CaseWorkers.Id " +
                    "INNER JOIN dbo.Customers " +
                    "ON dbo.Cases.CustomerId = dbo.Customers.Id " +
                    "INNER JOIN dbo.CaseStatus " +
                    "ON dbo.Cases.CaseStatusId = dbo.CaseStatus.Id"
                    )*/
                .ToListAsync();

        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cases>> GetCases(int id)
        {
            var _case = await _context.Cases.FindAsync(id);
            if (_case == null)
            {
                return NotFound();
            }

            return _case;
        }

        // PUT: api/Cases/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCases(int id, Cases cases)
        {
            if (id != cases.Id)
            {
                return BadRequest();
            }

            _context.Entry(cases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasesExists(id))
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

        // POST: api/Cases
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cases>> PostCases(Cases cases)
        {
            _context.Cases.Add(cases);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CasesExists(cases.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCases", new { id = cases.Id }, cases);
        }

        // DELETE: api/Cases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cases>> DeleteCases(int id)
        {
            var cases = await _context.Cases.FindAsync(id);
            if (cases == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(cases);
            await _context.SaveChangesAsync();

            return cases;
        }

        private bool CasesExists(int id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
